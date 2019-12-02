"use strict";

$(document).ready(function() {
    $('body, html').scrollTop($(document).height());
})

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

    var currentuser = document.getElementById("userName").value;

    var container = document.createElement('div');
   

    if (user == currentuser ) {
        container.classList.add("ChatContainerSender", "bg-light", "col-7" ,"offset-5","text-right","mt-3");
    } else {
        container.classList.add("ChatContainerRecipient", "bg-light","col-7","mt-3");
    }

    var  sender = document.createElement('p');
    sender.classList.add("ChatSender");
    sender.innerHTML = user;
    var  text = document.createElement('p');
    text.innerHTML = encodedMsg;

    var when = document.createElement('span');
    var currentdate = new Date();

    var dd = currentdate.getDate();

    if (dd < 10) {
        dd = '0' + dd;
    }

    when.innerHTML = dd
        + "." +
        (currentdate.getMonth() + 1) + "."
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('ru-RU', { hour: 'numeric', minute: 'numeric',second: 'numeric', hour12: false })

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

    var user = document.getElementById("userName").value;
    var message = document.getElementById("messageInput").value;
    var userID = document.getElementById("thisUserID").value;

    AddMessage(userID, message);

    document.getElementById("messageInput").value = "";
    $('body, html').scrollTop($(document).height());

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function AddMessage( userID, text ) {
    $.ajax({
        type: "POST",
        url: "/Chat/AddMessage/",
        data: { UserId: userID, Text: text },
        success: function (data) {
        },
        error: function () {
        }
    });
}