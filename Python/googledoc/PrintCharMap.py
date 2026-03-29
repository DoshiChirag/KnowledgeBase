import requests
from bs4 import BeautifulSoup

def load_unicode_char_map_from_google_doc(url):
    """
    Loads a Google Docs 'published' table containing:
        x-coordinate | Character | y-coordinate
    and returns a list of dicts: {x, y, char}
    """

    response = requests.get(url)
    response.raise_for_status()

    soup = BeautifulSoup(response.text, "html.parser")

    table = soup.find("table")
    rows = table.find_all("tr")

    char_map = []

    # Skip header row
    for row in rows[1:]:
        cols = [c.get_text(strip=True) for c in row.find_all(["td", "th"])]

        if len(cols) != 3:
            continue

        x_str, char, y_str = cols

        try:
            x = int(x_str)
            y = int(y_str)
        except ValueError:
            continue

        char_map.append({
            "x": x,
            "y": y,
            "char": char
        })

    return char_map

def print_unicode_map(char_map):
    if not char_map:
        return

    width = max(c["x"] for c in char_map) + 1
    height = max(c["y"] for c in char_map) + 1

    grid = [[" "]*width for _ in range(height)]

    for c in char_map:
        grid[c["y"]][c["x"]] = c["char"]

    for row in grid:
        print("".join(row))

url = "https://docs.google.com/document/d/e/2PACX-1vSvM5gDlNvt7npYHhp_XfsJvuntUhq184By5xO_pA4b_gCWeXb6dM6ZxwN8rE6S4ghUsCj2VKR21oEP/pub"
char_map = load_unicode_char_map_from_google_doc(url)

print("Loaded", len(char_map), "entries")
print_unicode_map(char_map)


