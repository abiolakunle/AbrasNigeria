import React from "react";

import QuotationList from "./Components/Quotation/QuotationList";
import Quotation from "./Components/Quotation/Quotation";
import ViewQuotation from "./Components/Quotation/ViewQuotation";
import SendQuotation from "./Components/Quotation/SendQuotation";

import { BrowserRouter as Router, Route } from "react-router-dom";
import history from "./history";

import { Provider } from "./Context";

function App() {
  return (
    <Provider>
      <Router history={history}>
        <Route exact path="/quotation/:id" component={Quotation} />
        <Route exact path="/quotation/" component={Quotation} />
        <Route exact path="/" component={QuotationList} />
        <Route exact path="/view/:id" component={ViewQuotation} />
        <Route exact path="/send" component={SendQuotation} />
        <Route exact path="/send/:id" component={SendQuotation} />
      </Router>
    </Provider>
  );
}

export default App;
