# ARTiculate : A venue for artists and artlovers

## Description
ARTiculate is an interactive mobile friendly web-application where artists can publish and share their artworks with the world. The application promotes live communication between artists and visitors during vernissages.   

## Prerequisites
In order to create and broadcast a live vernissage we recommend using Youtube live or any similar service. Use the https:// in the embedded link.

## Installation
To run the application you need to setup a local database.<br>
Go to appsettings.json and use the connection string using localdb.<br>
Open package manager console and type:

Update-database -Context ArtistContext <br>
Update-database -Context ARTiculateAuthDbContext

## Usage
To enjoy the application to it's full extent you need to create some content. Use the following steps in this order:

1. Create artist<br>
2. Add art items to your studio<br> 
2. Create exhibition<br>
3. Create vernissage<br>
4. Enjoy

## Authors
Evelina Söderberg (2021)<br>
Florim Bajrami (2021)<br>
Gustav Falk (2021)<br>
Jonathan Tynelius (2021)<br>
Magnus Hjelte (2021)<br>
Olivia Björner (2021)<br>
Patric Lindberg (2021)<br>
Pilvi Börjesson (2021)

## License
ARTiculate is licensed under GNU GPLv3.

## Acknowledgments
Thanks to Charlie Fredriksson and Erik Öberg at Mid Sweden University.
