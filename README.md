This repo shows how to connect an API from a WPF desktop app.

It´s developed in Visual Studio 2022 with C#.

The API is from www.openweathermap.org and gives back forecast for a huge amount of cities all over the world.

In its site you can find info about how to use the API. In order to use it, you need an API key given from the site.

I have defined my API key in an extra class (Constant.cs) as a public constant string and use it when I need it 

for connection. I added that class to .gitignore so it´s not in my repo online. You must get and add yor own 

API key to use this code.

The answer is a JSON string object. I have modeled a class FiveDaysModel.cs to deserialize that JSON string into a 

manageable object so I can access the values it holds.

To show the data, I use a Grid with TextBlocks (defined in MainWindow.xaml). The Text property of the TextBlocks 

is binded to the object created deserializing the JSON and mapped to concrete atributes.

Obviously you must change all the paths to resources!!

