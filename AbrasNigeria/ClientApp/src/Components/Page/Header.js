import React from "react";

const Header = () => {
  return (
    <React.Fragment>
      <div className="jumbotron jumbotron-fluid text-center">
        <div className="container">
          <h1 className="red-text display-5 text-uppercase font-weight-bolder">
            Abras nigeria enterprises
          </h1>
          <p className="lead">Dealers in all kinds of machine spare parts</p>
          <div className="pull-right">
            <p>
              <strong>Address: </strong>21/23 Apomu street, Ijegun, Lagos.
            </p>

            <p>
              <strong>Phone: </strong>+234 808 9568 4848
            </p>

            <p>
              <strong>Email: </strong>Abrasnigent@gmail.com
            </p>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Header;
