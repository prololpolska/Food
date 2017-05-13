var LoginLookNameSpace = {
click:"Login",
    Logon: function() {
        document.getElementById("form1").style.transform = "rotateY(180deg)";
        document.getElementById("form2").style.transform = "rotateY(0deg)";
        document.getElementById("logon").style.background = "yellow";
        document.getElementById("logon").style.color = "red";
    },
    LogonOut: function() {
        if (this.click === "Login") {
            document.getElementById("logon").style.background = "navy";
            document.getElementById("logon").style.color = "yellow";
            this.Login();
        }
    },
    LogonClick: function() {
        this.click = "Logon";
        document.getElementById("login").style.background = "navy";
        document.getElementById("login").style.color = "yellow";
        this.Logon();
    },
    Login: function() {
        document.getElementById("form1").style.transform = "rotateY(0deg)";
        document.getElementById("form2").style.transform = "rotateY(180deg)";
        document.getElementById("login").style.background = "yellow";
        document.getElementById("login").style.color = "red";
    },
    LoginOut: function() {
        if (this.click === "Logon") {
            document.getElementById("login").style.background = "navy";
            document.getElementById("login").style.color = "yellow";
            this.Logon();
        }
    },
    LoginClick: function() {
        this.click = "Login";
        document.getElementById("logon").style.background = "navy";
        document.getElementById("logon").style.color = "yellow";
        this.Login();
    }
}

var LoginValidationNameSpace = {
    password: null,
    userName: null,
    email: null,
    LogonClick: function () {
        this.password = document.getElementById("passwordR").value.trim();
        this.email = document.getElementById("emailR").value.trim();
        this.userName = document.getElementById("userNameR").value.trim();
        if (this.password.length < 8 || this.password.length > 16)
        {
            document.getElementById("LogonError").style.display = "inline";
        } else
        {
            document.getElementById("LogonSubmit").click();
        }
    },
    LoginClick: function () {
        this.password = document.getElementById("password").value.trim();
        this.email = document.getElementById("email").value.trim();

        if (this.password.length < 8 || this.password.length > 16) {
            document.getElementById("LoginError").style.display = "inline";
        } else {
            document.getElementById("LoginSubmit").click();
        }
    }
}