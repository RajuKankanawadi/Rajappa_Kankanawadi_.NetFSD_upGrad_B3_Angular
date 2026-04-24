"use strict";
function getWelcomeMessage(name) {
    return `Welcome ${name}`;
}
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `${name} is ${age} years old`;
    }
    return `${name} details not complete`;
}
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed ? `${name} is subscribed` : `${name} is not subscribed`;
}
function isEligibleForPremium(age) {
    return age > 18;
}
const greet = (name) => {
    return `Hello ${name}`;
};
const NotificationService = {
    appName: "NotifyApp",
    showMessage: (user) => {
        return `Welcome to ${NotificationService.appName}, ${user}`;
    }
};
console.log(getWelcomeMessage("Rajappa"));
console.log(getUserInfo("Shiva", 23));
console.log(getUserInfo("Kiran"));
console.log(getSubscriptionStatus("Shiva", true));
console.log(isEligibleForPremium(24));
console.log(greet("Shiva"));
console.log(NotificationService.showMessage("Kiran"));
