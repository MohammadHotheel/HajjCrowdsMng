﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Explorer.ascx.cs" Inherits="HCM.WebApp.UC.Explorer" %>
<link type="text/css" rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:300,400,500,700">
<style>
    /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
    #CompaniesLocations {
        height: 100%;
    }
</style>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDHMODO5cFiHcTUai5mSp8NhEqMvYtqNVA&v=3.exp&sensor=false"></script>

<script type="text/javascript">
    //Constants
    var map;
    var allLocations = JSON.parse('<%= FillServiceInfo() %>');

    //Render Map with results
    $(document).ready(function () {
        var defaultLatitude = -88.3287354;
        var defaultLongitude = 36.6169065;

        if (allLocations.length > 0) {
            defaultLatitude = allLocations[0].Latitude;
            defaultLongitude = allLocations[0].Longitude;
        }
        map = new google.maps.Map(document.getElementById("ServiceInfoLocations"), {
            zoom: 12,
            center: new google.maps.LatLng(defaultLatitude, defaultLongitude),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        var infowindow = new google.maps.InfoWindow();
        var marker, i;
        i = 0;

        $.each(allLocations, function (index, value) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(value.Latitude, value.Longitude),
                icon: src = "/Content/img/googleMaps.png",
                map: map
            });
            google.maps.event.addListener(marker, "click", (function (marker, i) {
                return function () {
                    infowindow.setContent("<b>" + value.Title + "</b><p>" + value.ServiceCategory + "</p>");
                    infowindow.open(map, marker);
                }
            })(marker, i));
            i += 1;
        });
    });
</script>

<div class="row">
    <div class="col-md-12">
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="ddlServiceCategory" CssClass="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","SelectCat") %></asp:Label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlServiceCategory" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="true">
                    <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, AllCat %>'></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="form-group">
            <div id="ServiceInfoLocations" style="height: 400px;"></div>
        </div>
    </div>
</div>
