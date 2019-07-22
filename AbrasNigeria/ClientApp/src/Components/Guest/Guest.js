import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";

import GuestHeader from "./Shared/GuestHeader";
import GuestFooter from "./Shared/GuestFooter";
import Home from "./Pages/Home";
import Machines from "./Pages/Machines";
import Machine from "./Pages/Machine";
import Contact from "./Pages/Contact";
import Products from "./Pages/Products";

class Guest extends Component {
  render() {
    return (
      <React.Fragment>
        <GuestHeader />
        <main className="container py-5">
          <Switch>
            <Route exact path="/" component={Home} />
            <Route exact path="/guest/home" component={Home} />
            <Route exact path="/guest/machines" component={Machines} />
            <Route exact path="/guest/machine/:id" component={Machine} />
            <Route exact path="/guest/contact" component={Contact} />
            <Route exact path="/guest/products" component={Products} />
          </Switch>
        </main>
        <GuestFooter />
      </React.Fragment>
    );
  }
}

export default Guest;
