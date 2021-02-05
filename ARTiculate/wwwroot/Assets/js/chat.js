"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub/").build();
var group = document.getElementById("vernissage-id").innerHTML;

console.log(group);


//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    var chatHistory = document.getElementById("chat-textbox");
    chatHistory.scrollTop = chatHistory.scrollHeight;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message, group).catch(function (err) {
    return console.error(err.toString());   

    });
    event.preventDefault();  
});

document.getElementById("join-chat").addEventListener("click", function (event) {

    document.getElementById("join-chat").style.display = "none";
    document.getElementById("sendButton").style.visibility = "visible";
    document.getElementById("userInput").style.visibility = "visible";
    document.getElementById("messageInput").style.visibility = "visible";
    document.getElementById("chat-textbox").style.visibility = "visible";
    connection.invoke("Connect", group).catch(function (err) {
        return console.error(err.toString());

    });
    event.preventDefault();
});