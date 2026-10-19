*** Settings ***
Library    SeleniumLibrary
Suite Teardown    Close All Browsers

*** Variables ***
${Browser}  Chrome
${NavigateURL}  http://www.google.com


*** Test Cases ***
Open Chrome
    Open Browser    ${NavigateURL}    ${Browser}
    Title Should Be    Google
    Close Browser

Checking google Searching
    SeleniumLibrary.Create Webdriver   ${Browser}
    Go To   ${NavigateURL}
    Title Should Be    Google
    Close Browser
