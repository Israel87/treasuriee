$(document).ready(() => {
    const api = axios.create({ baseURL: 'http://localhost:3000/records/' });
    var _activeSession = sessionStorage.getItem('_activeUserId');
    var recordlist = [];
  
  
    
  
    // the middleware proper starts here 
    if (_activeSession === null || _activeSession === '' || _activeSession === undefined) {
        window.location.href = 'login.html';
    }
    else {
        // get the list of the saved records starts here 
      
        // store the list of items in the variable below.
        var html = "";

        // code to view more actions 
        viewMore = () => {
            // 
        }
       
        // api.get('/getrecords').then((response) => {
        //     recordlist = response.data;
        //     console.log(recordlist);
        //     var displayResult = document.getElementById('displayResult');
        //     if(recordlist.length === 0 ){
        //         displayResult = "No record found yet";
        //     }else {
        //         // using old javascript to loop thorugh and populate the table with returned data.
        //         for (var i = 0; i < recordlist.length; i++) {
        //         console.log(recordlist[i].firstname);
        //            // using ES6 Template literals to create table body and append to html
        //            html += `<tr><td> ${recordlist[i].Id}</td>
        //                 <td> ${recordlist[i].firstname}</td>
        //                 <td> ${recordlist[i].middlename}</td>
        //                 <td> ${recordlist[i].lastname}</td>
        //                 <td> ${recordlist[i].address}</td>
        //                 <td> ${recordlist[i].email}</td>
        //                 <td> ${recordlist[i].phonenumber}</td>
        //                 <td> ${recordlist[i].country}</td>
        //                 <td><button class="btn btn-primary" onclick="${viewMore()}"> View More </button></td>
        //            </tr>`;

        //            displayResult.innerHTML = html;
        //         }
                
        //     }
       
        //     })
        //     .catch((error) => {
        //         console.log(error);
        //     });
    }

    // ends here 

 document.getElementById('save').addEventListener('click', () => {
      // establish the connection with the URL below
      // const api = axios.create({ baseURL: 'http://localhost:3000/records' });
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

      const config = {
        headers: {
          'Content-Type': 'application/json'
        }
      }
     // var data = JSON.stringify(_data);
      console.log(data);

      // begin the AXIOS work here 
      api.post('saverecord', data, config).then(response => {
            console.log(response);
            if (response.statusText === 'OK') {
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

});