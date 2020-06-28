
    jQuery(document).ready(function ($) {
        var doSth = function () {


            $("#tblStudent tbody td").remove();


            $.ajax({
                type: 'Get',
                url: '@Url.Action("getAllhRec")',
                dataType: 'json',
                data: {},
                success: function (data) {



                    var items = '';
                    $.each(data, function (i, item) {

                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }
                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }
                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }




                        var rows =
                            trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2






                                      + ""
                                      + "<td class='prtoducttd'>" +



                                      item.status + "</td>"
                                      + "<td class='prtoducttd'>" + item.category + "</td>"
                                      + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                                         + "<td class='prtoducttd'>" + item.description + "</td>"

                                      + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"



                                      + archive

                                      + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                                      + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                                      + "</tr>";

                        $('#tblStudent tbody').append(rows);
                                  });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });

        }
        setInterval(doSth, 100000000000);//1000 is miliseconds
















        $("#btnRef").click(function () {

            $("#tblStudent tbody td").remove();
            $("#tblStudent tbody ").append("<center><div id='loader'><img src='/Content/loader.gif' width='100' height='100'></a></div></center>");

            $.ajax({
                type: 'Get',
                url: '@Url.Action("getAllhRec")',
                dataType: 'json',
                data: {},
                timeout: 5000,
                success: function (data) {
                    $("#loader").remove();



                    var items = '';
                    $.each(data, function (i, item) {

                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }
                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }


                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }

                        var rows =
                            trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"



                        + archive

                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";

                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });











        $("#allAllRec").click(function () {

            $("#tblStudent tbody td").remove();

            $.ajax({
                type: 'Get',
                url: '@Url.Action("getAllhRec")',
                dataType: 'json',
                data: {},
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {

                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/"+item.id+"'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }

                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }
                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }

                        var rows =
                           trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"



                        + archive

                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });

        $("#allRec").click(function () {

            $("#tblStudent tbody td").remove();
            $.ajax({
                type: 'Get',
                url: '@Url.Action("getAllNoRec")',
                dataType: 'json',
                data: {},
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {
                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }

                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }
                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }

                        var rows = trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"
                        + archive
                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });


        $("#archRec").click(function () {

            $("#tblStudent tbody td").remove();
            $.ajax({
                type: 'Get',
                url: '@Url.Action("getArchRec")',
                dataType: 'json',
                data: {},
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {
                        var archive;


                        if (item.archivable == true) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }

                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }


                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }
                        var rows = trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"
                        + archive
                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });


        $("#searchTechnique").click(function () {
            $("#searchTechnique i").css("background-color", "red");
            $("#searchTechnique i").css("border-radius", "100%");

            $("#searchFin i").css("background-color", "white");
            $("#searchFin i").css("border-radius", "0%");

            $("#searchAutre i").css("background-color", "white");
            $("#searchAutre i").css("border-radius", "0%");



            $("#tblStudent tbody td").remove();

            $.ajax({
                type: 'Get',
                url: '@Url.Action("getRecByTechnique")',
                dataType: 'json',
                data: {},
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {
                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }
                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }

                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }
                        var rows = trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2
                        + "<td class='prtoducttd'>" +item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                        + "<td class='prtoducttd'>" + item.description + "</td>"
                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"
                        + archive
                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"
                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });










        $("#searchFin").click(function () {




            $("#searchFin i").css("background-color", "yellow");
            $("#searchFin i").css("border-radius", "100%");

            $("#searchTechnique i").css("background-color", "white");
            $("#searchTechnique i").css("border-radius", "0%");

            $("#searchAutre i").css("background-color", "white");
            $("#searchAutre i").css("border-radius", "0%");



            $("#tblStudent tbody td").remove();
            $.ajax({
                type: 'Get',
                url: '@Url.Action("getRecByFin")',
                dataType: 'json',
                data: {},
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {
                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }
                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }
                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }
                        var rows = trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                         + archive2
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"
                        + archive
                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });






        $("#searchAutre").click(function () {



            $("#searchAutre i").css("background-color", "blue");
            $("#searchAutre i").css("border-radius", "100%");

            $("#searchTechnique i").css("background-color", "white");
            $("#searchTechnique i").css("border-radius", "0%");

            $("#searchFin i").css("background-color", "white");
            $("#searchFin i").css("border-radius", "0%");




            $("#tblStudent tbody td").remove();
            $.ajax({
                type: 'Get',
                url: '@Url.Action("getRecByAutres")',
                dataType: 'json',
                data: {},
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {
                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }
                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }

                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }
                        var rows = trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + "<td class='prtoducttd'>" + archive2+ "</td>"
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"
                        + archive

                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;





        });
        $("#searchRec").keyup(function () {
            var searchRec = $('#searchRec').val();



            $("#tblStudent tbody td").remove();
            $.ajax({
                type: 'Get',
                url: '@Url.Action("getRec")',
                dataType: 'json',
                data: { 'searchRec': searchRec },
                success: function (data) {
                    var items = '';
                    $.each(data, function (i, item) {
                        var archive;


                        if (item.archivable == false) {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/ArchiveReclamation/" + item.id + "'>Archivé</a></td>";
                        }
                        else {
                            archive = "<td class='prtoducttd'> <a href='/Reclamation/DeArchiveReclamation/" + item.id + "'>Dearchivé</a></td>";

                        }
                        var trme;


                        if (item.readableRec == "novue") {
                            trme = "<tr class='notReadYet'>"
                        }
                        else {
                            trme = "<tr class=''>"

                        }

                        var archive2;




                        var jsonObj = @Html.Raw(Json.Encode(ViewBag.employee));
                        console.log(jsonObj);

                        for (i = 0; i < jsonObj .length; i++)
                        {

                            if (item.employe_Id == jsonObj[i].id)
                            {

                                archive2="<td class='prtoducttd'> "+jsonObj[i].first_name+"</td>";
                            }



                        }
                        var rows = trme
                        + "<td class='prtoducttd'>" + item.id + "</td>"
                        + archive2
                        + "<td class='prtoducttd'>" +



                        item.status + "</td>"
                        + "<td class='prtoducttd'>" + item.category + "</td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/Details/" + item.id + "'>" + item.title + "</a></td>"
                                           + "<td class='prtoducttd'>" + item.description + "</td>"

                        + "<td class='prtoducttd'>" + item.dateReclamation + "</td>"
                        + archive
                        + "<td class='prtoducttd'><a href='/Reclamation/updateReclamation/" + item.id + "'>Update</a></td>"
                        + "<td class='prtoducttd'><a href='/Reclamation/deleteRec/" + item.id + "'>Delete</a></td>"

                        + "</tr>";
                        $('#tblStudent tbody').append(rows);
                    });
                },
                error: function (ex) {

                    var r = jQuery.parseJSON(ex.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            return false;




        });


    });


