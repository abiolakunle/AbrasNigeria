import React from "react";

import QuotationList from "./Components/QuotationList";
import Quotation from "./Components/Quotation";
import ViewQuotation from "./Components/ViewQuotation";

import { BrowserRouter as Router, Route } from "react-router-dom";

import { Provider } from "./Context";

function App() {
  return (
    <Provider>
      <Router>
        <Route exact path="/quotation/:id" component={Quotation} />
        <Route exact path="/quotation/" component={Quotation} />
        <Route exact path="/" component={QuotationList} />
        <Route exact path="/view/:id" component={ViewQuotation} />
      </Router>
    </Provider>
  );
}

export default App;
