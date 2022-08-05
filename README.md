This repo shows how to connect an API from a WPF desktop app.

It´s developed in Visual Studio 2022 with C#.

The API is from www.openweathermap.org and gives back forecast for a huge amount of cities all over the world.

The answer is a JSON string object. I have modeled a class FiveDaysModel.cs to deserialize that JSON string into a nanageable 

object so I can access the values it holds.

To show the data, I use a Grid with TextBlocks (defined in MainWindow.xaml). The Text property of the TextBlocks is binded 

to the object created deserializing the JSON and mapped to concrete atributes.

