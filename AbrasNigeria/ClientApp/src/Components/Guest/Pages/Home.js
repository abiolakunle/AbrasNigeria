import React, { Component } from "react";

//images
import Engine from "../images/engine_component.png";
import Filter from "../images/filters.png";
import CarouselGrader from "../images/gd655_1500x500.jpg";
import Pump from "../images/hydraulic_pump.jpg";
import CarouselFilters from "../images/Komatsu_filters_1274x500.jpg";
import CarouselExcavator from "../images/pc200_1053x500.jpg";
import Attachment from "../images/rsz_attachments.png";
import CarouselUndercarriage from "../images/undercarriage.jpg";
import undercarriage2 from "../images/undercarriage2.jpg";

export default class Home extends Component {
  render() {
    return (
      <React.Fragment>
        <main id="home" class="body-part ">
          {this.carousel()}

          <section class="services pt-100 pb-50">
            <div class="container-fluid">
              <div class="row mb-5">
                <div class="col-xl-6 mx-auto text-center">
                  <h4 class="text-uppercase section-title mb-100">
                    We meet your sparepart needs
                  </h4>
                </div>
              </div>
              <div class="row row-eq-height">
                <div class="col-md-4">
                  <div class="card">
                    <img class="card-img-top" src={Filter} alt="Filters" />
                    <div class="card-body">
                      <h5 class="card-title border-bottom pb-3">
                        Filters
                        <a href="#" class="float-right d-inline-flex share" />
                      </h5>
                      <p class="card-text">
                        We have a broad and forward-thinking scope of channels
                        that guarantee solid execution that expands the life of
                        the segments and frameworks of the different machines.
                        Notwithstanding channels for extra parts, we also supply
                        other types of filters of different materials, pressure
                        filters, return filters and low and high pressure
                        suction filters.
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="card">
                    <img class="card-img-top" src={Engine} alt="Engine" />
                    <div class="card-body">
                      <h5 class="card-title border-bottom pb-3">
                        Engine components
                        <a href="#" class="float-right d-inline-flex share" />
                      </h5>
                      <p class="card-text">
                        We stock parts for most machine engines in the domestic
                        market, like chains, rims, chains, chains, links,
                        rollers, guide wheels, nuts and bolts, bushes, seals,
                        collars, cylinders, bushings and shafts, injector pumps,
                        engine heads, crankshafts, liners, racks, brakes,
                        blocks, connecting rods, pistons, cylinder covers,
                        filters, etc. Prices and availability of parts upon
                        request.
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="card">
                    <img class="card-img-top" src={Pump} alt="Pump" />
                    <div class="card-body">
                      <h5 class="card-title border-bottom pb-3">
                        Hydraulic pumps
                        <a href="#" class="float-right d-inline-flex share" />
                      </h5>
                      <p class="card-text">
                        We have the answer for the most incessant faults in
                        hydraulic pumps for backhoe and industrial machines. We
                        have hydraulic pumps in stock for most of the machines
                        in the national market in a complete offer with various
                        models of gear pumps and pistons.
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="card">
                    <img
                      class="card-img-top"
                      src={undercarriage2}
                      alt="undercarriage"
                    />
                    <div class="card-body">
                      <h5 class="card-title border-bottom pb-3">
                        Undercarriage
                        <a href="#" class="float-right d-inline-flex share" />
                      </h5>
                      <p class="card-text">
                        We have a huge load of elastic tracks for most machines
                        in the national market. Elastic tracks, rollers,
                        rippers, sections and connectors.
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="card">
                    <img
                      class="card-img-top"
                      src={Attachment}
                      alt="attachments"
                    />
                    <div class="card-body">
                      <h5 class="card-title border-bottom pb-3">
                        Attachments
                        <a href="#" class="float-right d-inline-flex share" />
                      </h5>
                      <p class="card-text">
                        Attachments sold by Abras Nigeria Parts incorporate
                        Buckets, Drills, Forks, Blades and Rippers. These pieces
                        provided to the measure, are the ones demonstrated to
                        satisfy your targets. Being this a significant point,
                        our range of accessories covers various brands of
                        industrial machines, among them, Caterpillar, Komatsu,
                        Case, JCB, New Holland and some more.
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </section>

          {/* @*<div class="brands">
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_bomag.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_caterpillar.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_cummins.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_daewoo.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_dynapac.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_hitachi.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_jcb.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_john-deere.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_komatsu.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_perkins.png" />
     </div>
     <div class="brand-logo">
         <img src="~/images/brand_logos/c_volvo.png" />
     </div>
 </div>*@ */}
        </main>
      </React.Fragment>
    );
  }

  carousel() {
    return (
      <div class="row shadow-sm mb-3">
        <div class="col-md-8 px-0">
          <div id="demo" class="carousel slide" data-ride="carousel">
            {/* <!-- Indicators --> */}
            <ul class="carousel-indicators">
              <li data-target="#demo" data-slide-to="0" class="active" />
              <li data-target="#demo" data-slide-to="1" />
              <li data-target="#demo" data-slide-to="2" />
            </ul>

            {/* <!-- The slideshow --> */}
            <div class="carousel-inner">
              <div class="carousel-item active">
                <img src={CarouselGrader} alt="grader" />
              </div>
              <div class="carousel-item">
                <img src={CarouselFilters} alt="filters" />
              </div>
              <div class="carousel-item">
                <img src={CarouselExcavator} alt="excavator" />
              </div>
            </div>

            {/* <!-- Left and right controls --> */}
            <a class="carousel-control-prev" href="#demo" data-slide="prev">
              <span class="carousel-control-prev-icon" />
            </a>
            <a class="carousel-control-next" href="#demo" data-slide="next">
              <span class="carousel-control-next-icon" />
            </a>
          </div>
        </div>
        <div class="col-md-4 px-0 ">
          <div class="card rounded-0 h-100">
            <div class="card-header bg-light shadow-sm">
              <h3 class="text-primary text-center font-weight-bolder text-uppercase">
                Abras Nigeria Enterprises
              </h3>
            </div>
            <div class="card-body px-5 font-italic text-center">
              <p class="">
                "At the point when your machines quit working, because of
                glitch, confusion settles in! "
              </p>
              <p class="">
                "With long stretches of market, and information of the business,{" "}
                <strong class="text-primary">Abras Nigeria Enterprise</strong>{" "}
                is the perfect accomplice, distinguishing and explaining your
                needs in an auspicious way."
              </p>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
