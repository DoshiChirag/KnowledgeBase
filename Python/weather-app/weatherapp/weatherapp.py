import requests

api_key = 'aaaaaa'


#A function that usee the requests libraray to make a GET 
#request to the OpenWeatherMap API for a certain location

def get_weather(location):
    
    base_url = "http://api.openweathermap.org/data/2.5/weather"
    params = {
        'q': location,
        'appid': api_key,}
    response = requests.get(base_url, params=params)
    data = response.json()
    print(data)
    if response.status_code == 200:
        main = data['main']
        high_temp = main['temp_max']
        low_temp = main['temp_min']
        return high_temp, low_temp
    else:
        return None