import weatherapp
# Ask user for their desired location to lookup weather for
location = input("Enter the location (city name or city,country code): ")

#Use the function in weatherapp.py to get the weather for their location
high, low = weatherapp.get_weather(location)

def convert_kelvin_to_fahrenheit(kelvin_temp):
    """Convert temperature from Kelvin to Celsius."""
    celsius_temp = kelvin_temp - 273.15
    fahrenheit_temp = (celsius_temp * 9/5) + 32
    return fahrenheit_temp

#Print the high and low temperatures in fahrenheit for the location
if high is not None and low is not None:
    high_f = convert_kelvin_to_fahrenheit(high)
    low_f = convert_kelvin_to_fahrenheit(low)
    print(f"The high temperature in {location} is {high_f}F")
    print(f"The low temperature in {location} is {low_f}F")
else:
    print("Sorry, could not retrieve weather data for that location.")



