import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import { Image, Transformation } from "cloudinary-react";

import { getStock } from "../../../Actions/stockActions";
import AddToCartBtn from "../Partials/AddToCartBtn";

//images
import Engine from "../images/engine_component.png";
import Filter from "../images/filters.png";
import CarouselGrader from "../images/gd655_1500x500.jpg";
import Pump from "../images/hydraulic_pump.jpg";
import CarouselFilters from "../images/Komatsu_filters_1274x500.jpg";
import CarouselExcavator from "../images/pc200_1053x500.jpg";
import Attachment from "../images/rsz_attachments.png";
//import CarouselUndercarriage from "../images/undercarriage.jpg";
import undercarriage2 from "../images/undercarriage2.jpg";

import HeaderFooter from "../Shared/HeaderFooter";
import shuffleArray from "../../../Utils/shuffleArray";

class Home extends Component {
  render() {
    const { stockItems } = this.props;

    return (
      <HeaderFooter>
        <React.Fragment>
          <BigCarousel />
          <MatrixCarousel>
            {stockItems.map((item, index) => {
              const { partNumber, descriptions, brand } = item;
              return (
                <div key={index} className="card row pb-2">
                  <Image publicId={item.imageUrl} height="250">
                    <Transformation height="357" width="165" crop="mfit" />
                  </Image>
                  <hr />
                  <span>
                    <Link to={`/guest/product/${partNumber}`}>
                      {partNumber}
                    </Link>
                    <br />
                    {brand}
                    <br />
                    {descriptions}
                  </span>
                  <AddToCartBtn product={{ partNumber, descriptions }} />
                </div>
              );
            })}
          </MatrixCarousel>
          <SectionsList />
        </React.Fragment>
      </HeaderFooter>
    );
  }

  componentDidMount = () => {
    this.props.getStock();
  };
}

const BigCarousel = () => {
  return (
    <div className="row shadow-sm mb-3">
      <div className="col-md-8 px-0">
        <div id="demo" className="carousel slide" data-ride="carousel">
          {/* <!-- Indicators --> */}
          <ul className="carousel-indicators">
            <li data-target="#demo" data-slide-to="0" className="active" />
            <li data-target="#demo" data-slide-to="1" />
            <li data-target="#demo" data-slide-to="2" />
          </ul>

          {/* <!-- The slideshow --> */}
          <div className="carousel-inner">
            <div className="carousel-item active">
              <img src={CarouselGrader} alt="grader" />
            </div>
            <div className="carousel-item">
              <img src={CarouselFilters} alt="filters" />
            </div>
            <div className="carousel-item">
              <img src={CarouselExcavator} alt="excavator" />
            </div>
          </div>

          {/* <!-- Left and right controls --> */}
          <a className="carousel-control-prev" href="#demo" data-slide="prev">
            <span className="carousel-control-prev-icon" />
          </a>
          <a className="carousel-control-next" href="#demo" data-slide="next">
            <span className="carousel-control-next-icon" />
          </a>
        </div>
      </div>
      <div className="col-md-4 px-0 ">
        <div className="card rounded-0 h-100">
          <div className="card-header bg-light shadow-sm">
            <h4 className="text-primary text-center font-weight-bolder text-uppercase">
              Abras Nigeria Enterprises
            </h4>
          </div>
          <div className="card-body px-5 font-italic text-center">
            <p className="">
              "At the point when your machines quit working, because of glitch,
              confusion settles in! "
            </p>
            <p className="">
              "With long stretches of market, and information of the business,{" "}
              <strong className="text-primary">Abras Nigeria Enterprise</strong>{" "}
              is the perfect accomplice, distinguishing and explaining your
              needs in an auspicious way."
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

const SectionsList = () => {
  return (
    <React.Fragment>
      <section className="services pt-100 pb-50">
        <div className="container-fluid">
          <div className="row mb-1">
            <div className="col-xl-6 mx-auto text-center">
              <h4 className="text-uppercase section-title mt-5">
                We meet your sparepart needs
              </h4>
            </div>
          </div>
          <div className="row row-eq-height">
            <div className="col-md-4 mb-2">
              <div className="card">
                <img className="card-img-top" src={Filter} alt="Filters" />
                <div className="card-body">
                  <h5 className="card-title border-bottom pb-3">Filters</h5>
                  <p className="card-text">
                    We have a broad and forward-thinking scope of channels that
                    guarantee solid execution that expands the life of the
                    segments and frameworks of the different machines.
                    Notwithstanding channels for extra parts, we also supply
                    other types of filters of different materials, pressure
                    filters, return filters and low and high pressure suction
                    filters.
                  </p>
                </div>
              </div>
            </div>
            <div className="col-md-4 mb-2">
              <div className="card">
                <img className="card-img-top" src={Engine} alt="Engine" />
                <div className="card-body">
                  <h5 className="card-title border-bottom pb-3">
                    Engine components
                  </h5>
                  <p className="card-text">
                    We stock parts for most machine engines in the domestic
                    market, like chains, rims, chains, chains, links, rollers,
                    guide wheels, nuts and bolts, bushes, seals, collars,
                    cylinders, bushings and shafts, injector pumps, engine
                    heads, crankshafts, liners, racks, brakes, blocks,
                    connecting rods, pistons, cylinder covers, filters, etc.
                    Prices and availability of parts upon request.
                  </p>
                </div>
              </div>
            </div>
            <div className="col-md-4 mb-2">
              <div className="card">
                <img className="card-img-top" src={Pump} alt="Pump" />
                <div className="card-body">
                  <h5 className="card-title border-bottom pb-3">
                    Hydraulic pumps
                  </h5>
                  <p className="card-text">
                    We have the answer for the most incessant faults in
                    hydraulic pumps for backhoe and industrial machines. We have
                    hydraulic pumps in stock for most of the machines in the
                    national market in a complete offer with various models of
                    gear pumps and pistons.
                  </p>
                </div>
              </div>
            </div>
            <div className="col-md-4 mb-2">
              <div className="card">
                <img
                  className="card-img-top"
                  src={undercarriage2}
                  alt="undercarriage"
                />
                <div className="card-body">
                  <h5 className="card-title border-bottom pb-3">
                    Undercarriage
                  </h5>
                  <p className="card-text">
                    We have a huge load of elastic tracks for most machines in
                    the national market. Elastic tracks, rollers, rippers,
                    sections and connectors.
                  </p>
                </div>
              </div>
            </div>
            <div className="col-md-4 mb-2">
              <div className="card">
                <img
                  className="card-img-top"
                  src={Attachment}
                  alt="attachments"
                />
                <div className="card-body">
                  <h5 className="card-title border-bottom pb-3">Attachments</h5>
                  <p className="card-text">
                    Attachments sold by Abras Nigeria Parts incorporate Buckets,
                    Drills, Forks, Blades and Rippers. These pieces provided to
                    the measure, are the ones demonstrated to satisfy your
                    targets. Being this a significant point, our range of
                    accessories covers various brands of industrial machines,
                    among them, Caterpillar, Komatsu, Case, JCB, New Holland and
                    some more.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </React.Fragment>
  );
};

const MatrixCarousel = ({ children }) => {
  shuffleArray(children);
  const stockMatrix = convertToMatrix(children, 4);

  return (
    <React.Fragment>
      <div className="container text-center my-3">
        <div
          id="recipeCarousel"
          className="carousel slide w-100"
          data-ride="carousel"
        >
          <div className="carousel-inner w-100" role="listbox">
            {stockMatrix.map((itemRow, index) => {
              return (
                <div
                  key={index}
                  className={`carousel-item row no-gutters ${
                    index === 0 ? "active" : ""
                  }`}
                >
                  {itemRow.map((itemCol, index) => {
                    return (
                      <div key={index} className="col-md-3 float-left">
                        {itemCol}
                      </div>
                    );
                  })}
                </div>
              );
            })}
          </div>
          <a
            className="carousel-control-prev w-40"
            href="#recipeCarousel"
            role="button"
            data-slide="prev"
          >
            <span class="fas fa-chevron-circle-left text-dark fa-3x"></span>
            <span className="sr-only">Previous</span>
          </a>
          <a
            className="carousel-control-next"
            href="#recipeCarousel"
            role="button"
            data-slide="next"
          >
            <span class="fas fa-chevron-circle-right text-dark fa-3x"></span>
            <span className="sr-only">Next</span>
          </a>
        </div>
      </div>
    </React.Fragment>
  );
};

const convertToMatrix = (array, colSize) => {
  return array.reduce((rows, value, index) => {
    return (
      (index % colSize === 0
        ? rows.push([value])
        : rows[rows.length - 1].push(value)) && rows
    );
  }, []);
};

const mapStateToProps = ({ stockReducer }) => {
  return {
    stockItems: stockReducer.stockItems
  };
};

const mapDispatchToProps = dispatch => {
  return {
    getStock: () => {
      dispatch(getStock());
    }
  };
};
export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Home);
