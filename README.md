# Software development for the cloud Project

## Project Name: Chefist
![GitHub Logo](/View_Chefsit.JPG)
## General Description
The following requirements are for a website application using ASP.NET, MySQL, Azure cloud and C# programming.
The website will allow users to create and publish recipes as well as to search these by cuisine and name.

## Main Requirements

- **R1 Log in**

    To log in you need to put in a username/email with a correct password

- **R2 Registration**

    To register the user needs to add a valid email, a username and password. Password shall be input twice for validation.

- **R3 View Recipes**

    Allow users to view the recipes on the front page

- **R4 Search**

    Allow for all users to search for a specific cuisine or dish to cook

- **R5 Filter**

    To filter out so you only get from a specific region (E.g. Japanese, Chinese, BBQ)

- **R6 Create recipes**

    Be able to create recipes, only if the user is registered. Guests are not allowed to create recipes. The owner of the recipe will be the user that created it.
To create a recipe the user must add the following details: Title, Cuisine (chosen from a drop down menu), ingredients incl. quantities.

- **R7 Delete**

   Be able to delete recipes, if the user is the owner of the recipe.

- **R8 Edit**

   Be able to edit recipes, if the user is the owner of the recipe.
Optional Requirements

- **R9 Comment**

    Users may comment on recipes as long as they are registered and logged in

- **R10 Change password**

   Allow users to change password to another, for security purposes.

- **R11 add Image**

   Users shall be able to add an image of the cooked dish to show the final product.

- **R12 Rating**

    Both registered and guest users may rate recipes.

- **R13 Forgotten password**
 
    Be able recover the password by email. The user may click on “Forgotten password?” after which an email will get sent to the corresponding email containing a link to reset it. 


## Architecture
![GitHub Logo](/chefist_architecture.JPG)


## Database

### User
- PK username
- email
- password (encrypted)


1(user)-M(recipes) 
### Recipes
- PK ID
- Name
- ingredients
- Description
- date
- Rating Average (optional)
- FK User
- Cuisine Name
- image PATH or blob

### Comments
- PK comment ID
- FK recipe ID
- (FK User:username) author
- Content
- datetime

### Ratings
- FK Recipe ID
- rating



# Routing


## Home

Home/ (index)

Home/Contact

Home/About

Home/Session (logged-in user)

Home/Session?search=noodle (Get request on Session of Home)

## Authorization

Auth/Login

Auth/Logout --just a message saying “you are logged out”

## User

User/Profile

User/Recipes

## Recipes

Recipe/Create

Recipe?Id=xxx  (get request on index of Recipe)

Recipe/Edit -- (if you are logged in as the owner OR Admin)

Recipe/Delete -- (if you are logged in as the owner OR Admin)
 

## Requirement Completion

Requirement | Completion Level
------------ | -------------
R1 Login | 100%
R2 Registration | 100%
R3 View | 100%
R4 Search | 100%
R5 Filter | 100% 
R6 Create | 100%
R7 Edit | 100%
R8 Delete | 100%
**Total**		|		   **100%**
