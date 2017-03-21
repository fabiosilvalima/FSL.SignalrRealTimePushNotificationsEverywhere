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
        messages.html(msg + '<br />' + messages.html());
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
            var msg = message.val();
            if (msg) {
                if (msg.substr(0, 4) === 'http') {
                    msg = '<a href="' + msg + '" target="_blank">' + msg  + '</a>';
                }
            }
            chatHub.server.sendMessage(user.val(), msg);
            message.val('');
        }
    });

    $.connection.hub.start();
});