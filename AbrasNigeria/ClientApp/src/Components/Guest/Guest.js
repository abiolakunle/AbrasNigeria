import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import GuestHeader from "./Shared/GuestHeader";
import GuestFooter from "./Shared/GuestFooter";
import Home from "./Pages/Home";
import Machines from "./Pages/Machines";
import Machine from "./Pages/Machine";

class Guest extends Component {
  render() {
    return (
      <React.Fragment>
        <GuestHeader />

        <Switch>
          <Route exact path="/guest/home" component={Home} />
          <Route exact path="/guest/machines" component={Machines} />
          <Route exact path="/guest/machine/:id" component={Machine} />
        </Switch>

        <GuestFooter />
      </React.Fragment>
    );
  }
}

export default Guest;
