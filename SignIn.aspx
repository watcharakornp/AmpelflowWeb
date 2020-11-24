<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="AmpelflowWeb.SignIn" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   

    <script src="../../Content/sbAdmin/vendor/jquery/jquery.min.js"></script>
    <link href="../../Content/sbAdmin/vendor/bootstrap/scss/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/sbAdmin/vendor/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Content/plugins/iCheck/all.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
    <link href="https://fonts.googleapis.com/css?family=Athiti" rel="stylesheet"/>
    <script src="https://code.iconify.design/1/1.0.7/iconify.min.js"></script>
    <script src="../../Content/plugins/iCheck/icheck.min.js"></script>
   

    <style>
		.bg{
			background-color: #f0efeb;
		}
		.thumbnail {
			opacity: 2;
			left: 50px;
			top: 200px;
			scrollbar-shadow-color: lawngreen;
            box-shadow:inherit;
		}

		.center {
			display: block;
			margin-left: auto;
			margin-right: auto;
			width: 80%;
		}
		.txtLabel {
            font-family: 'Athiti', sans-serif;
            font-size: 14px;
            font-weight: normal;
        }

        .hidden{
            display:none;
        }
	</style>

    <script>
        var macaddr;
        var mnu_ids = '';
        var emp_id = '<%= Session["emp_id"] %>';
        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0');
        var yyyy = today.getFullYear();
        var tt = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var currentdate = yyyy + '-' + mm + '-' + dd + ' ' + tt;
        var currentdate2 = yyyy + '-' + mm + '-' + dd;



        $(document).ready(function () {
            $(function () {
                $(".thumbnail").animate({ opacity: 1 }, { duration: 1500, queue: false });
                $(".thumbnail").animate({ "margin-top": "-40px" }, { duration: 500, queue: false });
            });

            //Clear Input
            var btnClear = $('#btnClear').click(function () {
                $('#txtUsername').val('');
                $('#txtPassword').val('');
            });


            $('#rememberCheck').iCheck({
                checkboxClass: 'icheckbox_flat-red',
                radioClass: 'iradio_flat-red'
            });

            $("#altDanger").fadeIn(800);
            macaddr = '<%= sMacAddress %>';
            //$('#txtMacAddress').val('<%= sMacAddress %>')

            GetDataSignIn();
            
        })

        function GetDataSignIn() {
          
            $.ajax({
                url: 'SignIn_srv.asmx/GetDataMemberSignIn',
                method: 'post',
                data: {
                    macaddress: macaddr },
                dataType: 'json',
                success: function (data) {
                    if (data != '') {
                        $.each(data, function (i, item) {
                            if (data[i].isremember == 1) {
                                $('#txtUsername').val(data[i].username);
                                $('#txtPassword').val(data[i].password);
                                $('#rememberCheck').iCheck('check');
                            }
                        });
                        
                    }
                }
            })
        }

    </script>



</head>
<body  class="txtLabel bg" onload="screenZoom()" >
    <%--<h2 id="macx2"><%= sMacAddress %></h2>--%>
    
    <div class="container  d-flex justify-content-center " >
		<div class="card thumbnail shadow" style="width:20rem;border-radius:15px">
            
			
			<div class="card-body" style="padding:0.9rem">
                    
                    <%= strErorConn %>
                
                <img class="center" src="../../Content/images/Logo-ampel-Big.png" style="padding-top: 10px;"/>
			  <h5 class="card-title text-center" style="font-size:25px;font-weight:700">
                  <br />
			  </h5>
                <form id="frmSignIn" runat="server">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><span class="iconify" data-icon="feather:user" data-inline="false"></span></span>
                        </div>
                        <input type="text" class="form-control" runat="server" id="txtUsername" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1" />
                        
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><span class="iconify" data-icon="carbon:password" data-inline="false"></span></span>
                        </div>
                        <input type="password" class="form-control" runat="server" id="txtPassword" placeholder="Password" aria-label="Username" aria-describedby="basic-addon1" />
                        
                    </div>
                    <%--<div class="input-group mb-3">--%>
                        <div class="input-group-prepend">
                            <input type="checkbox" id="rememberCheck">
                            
                            <p>&nbsp;&nbsp;Remember Password</p>
                        </div>
                        
                    <%--</div>--%>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col text-left" style="padding-left: 0;">
                                <button type="button" id="btnClear" class="btn btn-sm btn-outline-warning">Clear</button>
                            </div>
                            <div class="col text-right" style="padding-right: 0;">
                                <button type="button" runat="server" id="btnSignIn" onserverclick ="btnSignIn_click" class="btn btn-sm btn-outline-success hidden">SignIn</button>
                                <button type="button" onclick="onSignIn()" class="btn btn-sm btn-outline-success">SignIn</button>
                                <input type="text" name="name" class="hidden" runat="server" id="checkboxval"/>
                                <input type="text" runat="server" class="hidden" id="txtMacAddress" />
                            </div>
                        </div>
                    </div>

                </form>
			  
			</div>
		  </div>
	 </div>

    
    <!-- iCheck -->
    <%--<script src="../../Content/plugins/iCheck/icheck.min.js"></script>--%>
    <script>
    

        $("#txtPassword").keypress(function (e) {
            if (e.which == 13) {
                //onSignIn();
                $('#btnSignIn').click();
            }
        });
        
        function GetCheckMac() {
            var dataCount;
            $.ajax({
                url: 'SignIn_srv.asmx/GetDataMemberSignIn',
                method: 'post',
                data: {
                    macaddress: macaddr
                },
                dataType: 'json',
                success: function (data) {
                    if (data != '') {
                        dataCount = data.length;
                        return dataCount;
                    }
                }
            })
            
            
        }
        function onSignIninsert() {
            $.ajax({
                url: 'SignIn_srv.asmx/GetInsrememberSignIn',
                method: 'post',
                data: {
                    create_by: '<%= Session["usr_name"] %>',
                    create_date: currentdate2,
                    username: $('#txtUsername').val(),
                    password : $('#txtPassword').val(),
                    macaddress: macaddr,
                    isremember : 1
                },
                dataType: 'json',
                success: function (data) {
                    if (data == 'Success') {
                        return null;
                    }
                }
            })
        }

        function onSignInUpdate(status) {
            $.ajax({
                url: 'SignIn_srv.asmx/GetUpdaterememberSignIn',
                method: 'post',
                data: {
                    update_by: '<%= Session["usr_name"] %>',
                    update_date: currentdate2,
                    macaddress: macaddr,
                    isremember: status
                },
                dataType: 'json',
                success: function (data) {
                    if (data == 'Success') {
                        return null;
                    }
                }
            })
        }


        function onSignIn() {
            var CheckMac;
            if ($('#rememberCheck').is(':checked')) {
                document.getElementById('checkboxval').value = 1;
                CheckMac = GetCheckMac();
                if (CheckMac != 0) {                // มี Mac ใน Db
                    //alert('update');                // update status to 1
                    onSignInUpdate(1);
                } else if (CheckMac = 0) {          // ไม่มี Mac ใน Db
                    onSignIninsert();
                }
                
            } else {
                document.getElementById('checkboxval').value = 0;
                CheckMac = GetCheckMac();
                if (CheckMac != 0) {                    // มี Mac ใน Db
                    //alert('update');                    //update status to 0
                    onSignInUpdate(0);
                } else if (CheckMac = 0) {              // ไม่มี Mac ใน Db
                    return null;
                }
            }

            document.getElementById('<%= btnSignIn.ClientID%>').click();
        }


        function screenZoom() {
            var x = screen.width;
            if (x <= 1366) {
                //document.body.style.zoom = "80%"
                window.parent.document.body.style.zoom = 1;
                //myIframeZoom();             
            }
        };

        function myIframeZoom() {
            var x = document.getElementById("ifmBody");
            var y = (x.contentWindow || x.contentDocument);
            if (y.document) y = y.document;
            y.body.style.zoom = 0.9;
        };

    </script>
</body>
</html>
