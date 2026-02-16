importScripts('https://www.gstatic.com/firebasejs/9.23.0/firebase-app-compat.js');
importScripts('https://www.gstatic.com/firebasejs/9.23.0/firebase-messaging-compat.js');

firebase.initializeApp({
    apiKey: "AIzaSyAZZhAYEmdyuPWCB-14D1Vq9y7OUzBcnVA",
    authDomain: "notifications-68720.firebaseapp.com",
    projectId: "notifications-68720",
    messagingSenderId: "882368994384",
    appId: "1:882368994384:web:b68bca730dcf79d2734555"
});

const messaging = firebase.messaging();
