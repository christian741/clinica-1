<%@ Page Title="Galeria" Language="C#" MasterPageFile="~/View/Principal/MasterPrincipal.master" AutoEventWireup="true" 
    CodeFile="~/Controller/ConPrincipal/Galeria.aspx.cs" Inherits="View_Principal_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="bd-example" style="text-align:center;" >
          <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
              <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
              <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
              <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
              <li data-target="#carouselExampleCaptions" data-slide-to="3"></li>
              <li data-target="#carouselExampleCaptions" data-slide-to="4"></li>

            </ol>
            <div class="carousel-inner">
              <div class="carousel-item active">
                <img src="../../Imagenes/Proyecto/galeria1.jpg" width="50%" alt="..." >
                <div class="carousel-caption d-none d-md-block" style="color:black;">
                  <h5>Número Uno En Clínicas</h5>
                  <p>Somos El Mejor Centro Hospitalario Prestando Los Mejores Servicios.</p>
                </div>
                
            </a>
              </div>
              <div class="carousel-item">
                <img src="../../Imagenes/Proyecto/galeria2.jpg" width="60%" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:white;font-weight:bold">
                  <h5>Equipos Especializados</h5>
                  <p>Los Mejores Equipos Especialiazdos Para Atenderte.</p>
                </div>
              </div>
              <div class="carousel-item">
                <img src="../../Imagenes/Proyecto/galeria3.jpg" width="45%" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:black;font-weight:bold;">
                  <h5>Toda Clase De Especialistas</h5>
                  <p>Doctores principalmente Especializados Para Ti.</p>
                </div>
              </div>
                <div class="carousel-item">
                <img src="../../Imagenes/Proyecto/galeria4.jpg" width="50%" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:white;font-weight:bold;">
                  <h5>Tecnología Y Salud</h5>
                  <p>Prestamos Un Servicio Unico via Web .</p>
                </div>
              </div>
                <div class="carousel-item">
                <img src="../../Imagenes/Proyecto/gaeria5.jpg" width="50%" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:black;font-weight:bold;">
                  <h5>Hacemos Que Tu Doctor Este Mas Cerca De Ti</h5>
                  <p>Es Como Tener un Doctor que Te Cuide En Casa.</p>
                </div>
              </div>
                
            </div>
           
            
          </div>
        </div>

</asp:Content>

