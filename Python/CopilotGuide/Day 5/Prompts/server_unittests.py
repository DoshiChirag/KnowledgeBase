import json
import pytest
from app import create_app, VALID_TOKENS


@pytest.fixture
def client():
    app = create_app()
    app.config["TESTING"] = True
    with app.test_client() as client:
        yield client


def _auth_header(token=None):
    if token is None:
        return {}
    return {"Authorization": f"Bearer {token}"}


# ---------- Tests for auth decorator ----------

def TestCase_auth_missing_header(client):
    response = client.get("/hello")
    assert response.status_code == 401
    assert response.get_json()["error"] == "Unauthorized"


def TestCase_auth_malformed_header(client):
    response = client.get("/hello", headers={"Authorization": "Token abc"})
    assert response.status_code == 401
    assert response.get_json()["error"] == "Unauthorized"


def TestCase_auth_invalid_token(client):
    response = client.get("/hello", headers=_auth_header("invalid-token"))
    assert response.status_code == 401
    assert response.get_json()["error"] == "Unauthorized"


def TestCase_auth_valid_token(client):
    token = next(iter(VALID_TOKENS))
    response = client.get("/hello", headers=_auth_header(token))
    assert response.status_code == 200
    assert response.get_json()["message"] == "Hello World"


# ---------- Tests for GET /hello ----------

def TestCase_hello_null_token(client):
    # "NULL input" interpreted as missing/None token
    response = client.get("/hello", headers=_auth_header(None))
    assert response.status_code == 401


# ---------- Tests for POST /echo ----------

def TestCase_echo_valid_json(client):
    token = next(iter(VALID_TOKENS))
    payload = {"key": "value"}
    response = client.post(
        "/echo",
        headers=_auth_header(token),
        data=json.dumps(payload),
        content_type="application/json",
    )
    assert response.status_code == 200
    assert response.get_json()["received"] == payload


def TestCase_echo_null_body(client):
    token = next(iter(VALID_TOKENS))
    # No body at all
    response = client.post("/echo", headers=_auth_header(token))
    assert response.status_code == 400
    assert response.get_json()["error"] == "Invalid or missing JSON"


def TestCase_echo_invalid_json(client):
    token = next(iter(VALID_TOKENS))
    # Invalid JSON string
    response = client.post(
        "/echo",
        headers=_auth_header(token),
        data="not-json",
        content_type="application/json",
    )
    assert response.status_code == 400
    assert response.get_json()["error"] == "Invalid or missing JSON"


def TestCase_echo_missing_auth(client):
    response = client.post(
        "/echo",
        data=json.dumps({"x": 1}),
        content_type="application/json",
    )
    assert response.status_code == 401
    assert response.get_json()["error"] == "Unauthorized"