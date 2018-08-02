<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLocation.ascx.cs" Inherits="HCM.WebApp.UC.ucLocation" %>
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

<div class="row">
    <div class="col-md-12">
        <div id="dvMap" style="width: 100%; height: 500px">
        </div>
        Latitude:
        <%--<asp:Label ID="lblLat" runat="server" Text=""></asp:Label>--%>
        <asp:TextBox runat="server" ID="txtLat" CssClass="form-control" ReadOnly="true" />
        <asp:HiddenField ID="hfLat" runat="server" Value="" />
        Longitude:
        <%--<asp:Label ID="lblLng" runat="server" Text=""></asp:Label>--%>
        <asp:TextBox runat="server" ID="txtLng" CssClass="form-control" ReadOnly="true" />
        <asp:HiddenField ID="hfLng" runat="server" Value="" />

        <asp:HiddenField ID="hfZoom" runat="server" Value="12" />
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        showLocation();

        // Set New Location
        google.maps.event.addListener(map, 'click', function (e) {
            //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
            document.getElementById("<%=txtLat.ClientID%>").value = e.latLng.lat();
            document.getElementById("<%=txtLng.ClientID%>").value = e.latLng.lng();
            document.getElementById("<%=hfLat.ClientID%>").value = e.latLng.lat();
            document.getElementById("<%=hfLng.ClientID%>").value = e.latLng.lng();
            //innerHTML;
        });
    });

    function showLocation() {
        // Show Current Location
        defaultLatitude = '<%= (Lat != null ? Lat : "-101.11450356498995") %>';
        defaultLongitude = '<%= (Lng != null ? Lng : "39.55926832162305") %>';
        
        map = new google.maps.Map(document.getElementById("dvMap"), {
            zoom: parseInt('<%= (Zoom == 5 ? 5 : 12) %>'),
            center: new google.maps.LatLng(defaultLatitude, defaultLongitude),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });
        var infowindow = new google.maps.InfoWindow();
        var marker;
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(defaultLatitude, defaultLongitude),
            icon: src = "Content/img/googleMaps.png",
            map: map
        });
        google.maps.event.addListener(marker, "click", (function (marker) {
            return function () {
                infowindow.setContent("<b>" + '<%= Name %>' + "</b><p>" + '<%= Desc %>' + "</p>");
                infowindow.open(map, marker);
            }
        })(marker));
    }
</script>
