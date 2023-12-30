// script pre tlačidlo "Ukončiť počítadlo" na stránke results.aspx
function closeWindow() {
    window.close();
    return false; // Prevents postback if needed
};

// Function to display the login popup
function showPopup() {
    document.getElementById('overlay').style.display = 'block';
}

// Function to close the login popup
function closePopup() {
    document.getElementById('overlay').style.display = 'none';
}

// Function to handle login form submission
function submitLogin() {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    // Perform validation and authentication
    // On successful login, you might redirect the user or perform other actions$
    // For example: alert('Logged in as ' + username);

    // For demo purposes, just close the popup
    closePopup();
}

// Attach click event to the login button after the page has loaded
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('loginButton').addEventListener('click', showPopup);
    document.getElementById('closeButton').addEventListener('click', closePopup);
    document.getElementById('submitButton').addEventListener('click', submitLogin);

    // Close the popup when clicking outside of it
    window.onclick = function (event) {
        var overlay = document.getElementById('overlay');
        if (event.target == overlay) {
            overlay.style.display = 'none';
        }
    };
})

// funkcia tlačítka "Prehľad hry" na stránke "competition.aspx" - otvorí stránku "PriebehHry.aspx" v novom okne
function Button_prehlad_aktualnej_hry_Click() {
    window.open('PriebehHry.aspx');
}

// funkcia tlačítka "Zmeniť hráčov" na stránke "players.aspx" - otvorí stránku "vyberHracov.aspx" v tom istom okne
//function Button_zmenit_hracov_Click() {
//    window.location.href = 'vyberHracov.aspx';
//}
function Button_zmenit_hracov_Click() {
    window.location.href = 'vyberHracov.aspx?clear=true';
}

// funkcia tlačítka "Prejsť na hru" na stránke "players.aspx" - otvorí stránku "default1.aspx" v tom istom okne
function Button_prejst_na_hru_Click() {
    window.location.href = 'default1.aspx';
}

// funkcia tlačítka "Prejsť na zoznam vybratých hráčov" na stránke "vyberHracov.aspx" - otvorí stránku "players.aspx" v tom istom okne
function Button_prejst_na_zoznam_vybratych_hracov_Click() {
    window.location.href = 'players.aspx';
}

//function updateDiv(selectedPlayerID, player_name) {
//    var div = document.getElementById("Label_selectedPlayer");
//    label.innerText = "Vybratý hráč: " + selectedPlayerID + ". " + player_name;
//    alert("Function called with: " + selectedPlayerID + " and " + player_name);
//}