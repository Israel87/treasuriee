$(document).ready(function () {
  // get the session details here 
  var _activeSession = sessionStorage.getItem('_activeUserId');
  // the middleware proper starts here 
  if (_activeSession === null || _activeSession === '' || _activeSession === undefined) {
    window.location.href = 'login.html';
  } else {

    // clear the input field after saving the values
    clearInputFields = () => {
      document.getElementById('firstname').value = '';
      document.getElementById('middlename').value = '';
      document.getElementById('lastname').value = '';
      document.getElementById('address').value = '';
      document.getElementById('email').value = '';
      document.getElementById('phonenumber').value = '';
      document.getElementById('country').value = '';
    }


    // the code begins here 
    // get the values from the input fields 
    document.getElementById('save').addEventListener('click', () => {
      alert('got here...');
      // establish the connection with the URL below
      const api = axios.create({ baseURL: 'http://localhost:3000/records' });
      // get values from input fields 
      var _firstname = document.getElementById('firstname').value;
      var _middlename = document.getElementById('middlename').value;
      var _lastname = document.getElementById('lastname').value;
      var _address = document.getElementById('address').value;
      var _email = document.getElementById('email').value;
      var _phonenumber = document.getElementById('phonenumber').value;
      var _country = document.getElementById('country').value;


      // get the values into an object 
     data = {
        firstname: _firstname,
        middlename: _middlename
      //  country: _country
      }

      console.log(data);

      // begin the AXIOS work here 
      api.post('/saverecord', data).then((res) => {
        // check the returned value 
        alert('got here... 2');
        if (res.statusText === 'OK') {
          $.notify({
            icon: 'pe-7s-info',
            message: "<b>Success</b> - Record Saved."
          }, {
              type: 'info',
              timer: 4000
            });
          // set the values to null 
          clearInputFields();
        } else {
          $.notify({
            icon: 'pe-7s-info',
            message: "<b>Error</b> - Record failed to save."
          }, {
              type: 'error',
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
    // get the count of transactions done 
  }



});