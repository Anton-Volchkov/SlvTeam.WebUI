﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ChatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;

    if (msg.trim() =="") {
        return;
    }


    var chat = document.getElementById("messagesList");

    var currentuser = document.getElementById("userInput").value;

    var container = document.createElement('div');
   

    if (user == currentuser ) {
        container.classList.add("ChatContainerSender", "bg-light", "col-md-7" ,"offset-md-5");
    } else {
        container.classList.add("ChatContainerRecipient", "bg-light","col-md-7");
    }

    var  sender = document.createElement('p');
    sender.classList.add("ChatSender");
    sender.innerHTML = user;
    var  text = document.createElement('p');
    text.innerHTML = encodedMsg;

    var when = document.createElement('span');
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('ru-RU', { hour: 'numeric', minute: 'numeric', hour12: false })

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    document.getElementById("messageInput").value = "";
    $('body, html').scrollTop($(document).height());

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});