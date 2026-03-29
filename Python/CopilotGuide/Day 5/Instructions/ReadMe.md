## Gold Price API

A new Flask endpoint `/gold` has been added.  
It retrieves the current price of gold from a mock API endpoint and returns it as JSON.

### Endpoint
GET /gold

### Response Example
{
  "gold_price_usd": 1932.55,
  "source": "mock-api"
}

### Notes
- Update `MOCK_GOLD_API` in `app.py` to point to your actual mock endpoint.
- Server runs on port 5001.

## Gold Price History API

A new Flask endpoint `/gold/history` has been added.  
It retrieves the last 20 days of gold prices from a mock API endpoint.

### Endpoint
GET /gold/history

### Response Example
{
  "days": 20,
  "gold_price_history": [
    { "date": "2026-03-09", "price": 1922.55 },
    { "date": "2026-03-10", "price": 1930.12 },
    ...
  ],
  "source": "mock-api"
}

### Notes
- Update `MOCK_GOLD_API` to point to your actual mock endpoint.
- Server runs on port 5001.