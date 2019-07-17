import React from "react";

//imported images
import Cat from "../../../Images/c_caterpillar.png";
import Komatsu from "../../../Images/c_komatsu.png";
import Perkins from "../../../Images/c_perkins.png";
import Cummins from "../../../Images/c_cummins.png";
import Volvo from "../../../Images/c_volvo.png";

const Footer = () => {
  return (
    <React.Fragment>
      <div className="container d-flex justify-content-around  pt-5 mt-5">
        <div className="">
          <img src={Cat} height="50px" alt="Cat" />
        </div>
        <div className="">
          <img src={Komatsu} height="50px" alt="Komatsu" />
        </div>
        <div className="">
          <img src={Perkins} height="50px" alt="Perkins" />
        </div>
        <div className="">
          <img src={Cummins} height="50px" alt="Cummins" />
        </div>
        <div className="">
          <img src={Volvo} height="50px" alt="Volvo" />
        </div>
      </div>
    </React.Fragment>
  );
};

export default Footer;
