#include <iostream>                 // bringin' in tools for speakin' to the console
#include "httplib.h"                // bringin' aboard a simple HTTP server library
#include <curl/curl.h>              // fetchin' treasure from the Bitcoin API

// function to store fetched data from curl
size_t writeCallback(void* contents, size_t size, size_t nmemb, std::string* output) {
    size_t totalSize = size * nmemb;          // calculatin' how much loot we received
    output->append((char*)contents, totalSize); // stashin' the loot in our camelCase chest
    return totalSize;                          // tellin' curl how much we took aboard
}

int main() {
    httplib::Server pirateServer;              // creatin' our mighty server with camelCase

    pirateServer.Get("/bitcoin", [](const httplib::Request&, httplib::Response& response) {
        std::string apiUrl = "https://api.coindesk.com/v1/bpi/currentprice.json"; // the treasure map
        CURL* curlHandle = curl_easy_init();   // preparin' the curl ship
        std::string apiResponse;               // chest to hold the fetched treasure

        if (curlHandle) {
            curl_easy_setopt(curlHandle, CURLOPT_URL, apiUrl.c_str()); // settin' the destination
            curl_easy_setopt(curlHandle, CURLOPT_WRITEFUNCTION, writeCallback); // tellin' curl how to store loot
            curl_easy_setopt(curlHandle, CURLOPT_WRITEDATA, &apiResponse);      // pointin' to our treasure chest
            curl_easy_perform(curlHandle);     // sailin' out to fetch the Bitcoin price
            curl_easy_cleanup(curlHandle);     // cleanin' the deck after the voyage
        }

        response.set_content(apiResponse, "application/json"); // handin' the treasure to the visitor
    });

    std::cout << "Server be runnin' on port 8080, matey!" << std::endl; // announcin' the ship's location
    pirateServer.listen("0.0.0.0", 8080);          // settin' sail and listenin' for visitors

    return 0;                                      // endin' the voyage with no trouble
}