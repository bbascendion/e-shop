# eShop Automation Test Cases

## Overview
This repository contains automation test cases for the eShop capstone project, which was part of our training. The test cases are designed to validate the functionality and user experience of the eShop application. The tests cover various aspects such as login functionality, navigation, catalog filters, and order management.

## Test Framework
The tests are implemented using the Selenium WebDriver in combination with the NUnit testing framework. This setup allows for easy automation of browser interactions and provides a structured approach to testing web applications.

## Key Components
1. **Test Classes**:
   - `CatalogFiltersTest`: Contains tests for verifying catalog filters (brand, type) and pagination in the eShop catalog.
   - `MyOrdersTests`: Covers the tests related to the "My Orders" page, including navigation, header verification, and table visibility.
   - `NavigationTests`: Ensures proper navigation from the homepage to different pages, including the login and profile pages.

2. **Interfaces**:
   - `ICatalogFilters`: Defines methods for applying catalog filters and navigating through pages.
   - `IMyOrders`: Provides methods for handling actions on the "My Orders" page.

3. **Classes**:
   - `CatalogFilters`: Implements the `ICatalogFilters` interface to interact with catalog filters and manage pagination.
   - `MyOrders`: Implements the `IMyOrders` interface to handle navigation and verification on the "My Orders" page.
   - `NavigationAction`: A utility class for performing navigation-related actions like login, logout, and page redirection.

## How to Run the Tests
1. Clone the repository:
   ```bash
   git clone https://github.com/bbascendion/e-shop.git

We Done this automation for this project 
https://github.com/dotnet-architecture/eShopOnWeb
