function validateName() {
    var name = document.getElementById("name").value;
    var regex = /^[a-zA-Z ]{2,30}$/;
    if (regex.test(name)) {
        document.getElementById("name").style.border = "2px solid green";
    } else {
        document.getElementById("name").style.border = "2px solid red";
    }
}

function validateContactNo() {
    var phoneNumber = document.getElementById("phoneNumber").value;
    var regex = /^[6-9]\d{9}$/;
    if (regex.test(phoneNumber)) {
        document.getElementById("phoneNumber").style.border = "2px solid green";
    } else {
        document.getElementById("phoneNumber").style.border = "2px solid red";
    }
}

function emailValidation() {
    var email = document.getElementById("email").value;
    var regex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;
    if (regex.test(email)) {
        document.getElementById("email").style.border = "2px solid green";
    } else {
        document.getElementById("email").style.border = "2px solid red";
    }
}

function costCalculation() {
    var name = document.getElementById("name").value;
    var phoneNumber = document.getElementById("phoneNumber").value;
    var email = document.getElementById("email").value;
    var noofguests = document.getElementById("noofguests").value;
    var session = document.getElementsByName("session");
    var dateofvisit = document.getElementById("dateofvisit").value;
    var duration = document.getElementById("duration").value;
    var tableName = document.getElementById("tableName").value;
    var payment = document.getElementsByName("payment");
    var cardNumber = document.getElementById("cardNumber").value;
    var cvvNumber = document.getElementById("cvvNumber").value;
    var regex = /^[6-9]\d{9}$/;
    var regex1 = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;
    var regex2 = /^[a-zA-Z ]{2,30}$/;
    var regex3 = /^[0-9]{3,4}$/;
    var regex4 = /^[0-9]{16}$/;
    var sessionType;
    var paymentMode;
    var cost;
    var advancePayment;
    var result;
    var date = new Date();
    var currentDate = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
    var currentTime = date.getHours() + ":" + date.getMinutes();
    var currentSession;
    if (date.getHours() >= 12 && date.getHours() <= 15) {
        currentSession = "Lunch";
    } else if (date.getHours() >= 19 && date.getHours() <= 22) {
        currentSession = "Dinner";
    } else {
        currentSession = "No Session";
    }
    for (var i = 0; i < session.length; i++) {
        if (session[i].checked) {
            sessionType = session[i].value;
        }
    }
    for (var i = 0; i < payment.length; i++) {
        if (payment[i].checked) {
            paymentMode = payment[i].value;
        }
    }
    if (sessionType == "Lunch(12pm-3pm)") {
        if (noofguests <= 3) {
            cost = 625 * noofguests;
            advancePayment = 500;
        } else if (noofguests <= 6) {
            cost = 625 * noofguests;
            advancePayment = 1000;
        } else if (noofguests <= 10) {
            cost = 625 * noofguests;
            advancePayment = 2500;
        } else if (noofguests <= 20) {
            cost = 625 * noofguests;
            advancePayment = 4000;
        }
    } else if (sessionType == "Dinner(7pm-10pm)") {
        if (noofguests <= 3) {
            cost = 825 * noofguests;
            advancePayment = 600;
        } else if (noofguests <= 6) {
            cost = 825 * noofguests;
            advancePayment = 1200;
        } else if (noofguests <= 10) {
            cost = 825 * noofguests;
            advancePayment = 2750;
        } else if (noofguests <= 20) {
            cost = 825 * noofguests;
            advancePayment = 4200;
        }
    }
    if (regex.test(phoneNumber) && regex1.test(email) && regex2.test(name) && regex3.test(cvvNumber) && regex4.test(cardNumber)) {
        if (currentDate == dateofvisit) {
            if (currentSession == sessionType) {
                if (currentTime <= "12:00" && sessionType == "Lunch") {
                    result = "The Advanced Amount Rs. "+advancePayment + " is paid successfully Your table is Reservered And confirmed on " + dateofvisit;
                } else if (currentTime <= "19:00" && sessionType == "Dinner") {
                    result = "The Advanced Amount Rs. "+advancePayment + " is paid successfully Your table is Reservered And confirmed on " + dateofvisit;
                } else {
                    result = "Sorry, you can't reserve table for today.";
                }
            } else {
                result = "The Advanced Amount Rs. "+advancePayment + " is paid successfully Your table is Reservered And confirmed on " + dateofvisit;
            }
        } else {
            result = "The Advanced Amount Rs. "+advancePayment + " is paid successfully Your table is Reservered And confirmed on " + dateofvisit;
        }
    } else {
        result = "Please fill all the details correctly.";
    }
    document.getElementById("result").innerHTML = result;
    return false;
}