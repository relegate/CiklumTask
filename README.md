# CiklumTask

A test task program for Code Worldwide project. Implements a web application that parses an online shop and shows up items data from it.

# Some comments
The app is built on ASP.NET MVC, obviously. I am using a single-project model instead of creating multiple projects for each layer, since the app seems to be small.  
A SERP page is running with knockout.js. 
I've been using Unit of work design pattern when creating data access layer.

The parser part of the project appears as a separate module that runs hourly. I am using an API to get all the products, which are then parsed from XML to a model.

Price changes come as a chart available on Item Details page. Prices are updated hourly with parser. Honestly, couldn't find any light library to draw a chart, so I've used a simple out-of-the-box Chart, that is saving an Image of a chart instead. A little bit weird (super weird honestly), but i think it's ok.
