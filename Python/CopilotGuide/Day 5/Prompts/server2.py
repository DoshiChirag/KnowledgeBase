import logging
from django.http import JsonResponse, HttpResponse
from django.views.decorators.csrf import csrf_exempt

# Logging setup
LOGGER = logging.getLogger("SERVER_LOGGER")
LOGGER.setLevel(logging.INFO)

EXPECTED_TOKEN = "MYSECRETTOKEN"

def func_authenticate(request):
    AUTH_HEADER = request.headers.get("Authorization", "")
    if AUTH_HEADER.startswith("Bearer "):
        TOKEN = AUTH_HEADER.split(" ")[1]
        return TOKEN == EXPECTED_TOKEN
    return False

def func_hello_world(request):
    LOGGER.info("Received GET /hello request")
    if not func_authenticate(request):
        return HttpResponse("Unauthorized", status=401)
    MESSAGE = "Hello World"
    return JsonResponse({"message": MESSAGE})

@csrf_exempt
def func_post_data(request):
    LOGGER.info("Received POST /data request")
    if not func_authenticate(request):
        return HttpResponse("Unauthorized", status=401)
    if request.method != "POST":
        return HttpResponse("Method Not Allowed", status=405)
    DATA = request.body.decode("utf-8")
    return JsonResponse({"received": DATA})