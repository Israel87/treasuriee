// Login function starts here ___
$(document).ready(function () {
    sessionStorage.clear();
    document.getElementById('loginID').addEventListener('click', () => {
        // get the variables from the input fields 
        const api = axios.create({baseURL: 'http://localhost:3000/login'});
        var _username = document.getElementById('username').value;
        var _password = document.getElementById('password').value;
        data = {
            name: _username,
            password: _password
        }
        console.log(data);
        api.post('', data).then(response => {
                // check the returned value 
                if(response.data.length === 1){
                    // save data into sessions here _
                    sessionStorage.setItem('_activeUserId', response.data[0].Id);
                    window.location.href='./dashboard.html';
                    console.log(response.data);
                    // var _getSessionId = sessionStorage.getItem('_activeUserId');
                    // console.log(_getSessionId);
                } else {
                    console.log(response)
                    $.notify({
                        icon: 'pe-7s-info',
                        message: "<b>Error</b> - Incorrect Username / Password."
                    },{
                            type: 'danger',
                            timer: 4000
                    });
                }  
            })
            .catch(function (error) {
                console.log(error);
            })
            .then(function () {
                // always executed
    
            });
        })

});
// ends here ________