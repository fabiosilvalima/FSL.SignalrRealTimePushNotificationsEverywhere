/// <reference path="jquery.signalR-2.1.1.js" />
/// <reference path="jquery-1.10.2.js" />
/// <reference path="knockout.mapping-latest.debug.js" />
/// <reference path="knockout-2.0.0.js" />

$(document).ready(function () {
    var message = $('#message');
    var messages = $('#messages');
    var user = $('#user');
    var date = $('#date');

    var chatHub = $.connection.hub.proxies.chathub;

    chatHub.client.receiveMessage = function (msg) {
        messages.html(messages.html() + '<br />' + msg);
        chatHub.server.sendDateTimeServer();
    };

    chatHub.client.getDateTimeServer = function (d) {
        date.html(d);
    };

    chatHub.client.reportConnections = function (count) {
        $('#users').text(count);
    };

    message.keydown(function (key) {
        if (key.keyCode == 13) {
            chatHub.server.sendMessage(user.val(), message.val());
            message.val('');
        }
    });

    $.connection.hub.start();
});