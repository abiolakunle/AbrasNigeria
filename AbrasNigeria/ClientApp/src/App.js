import React from "react";

import QuotationList from "./Components/Quotation/QuotationList";
import Quotation from "./Components/Quotation/Quotation";
import ViewQuotation from "./Components/Quotation/ViewQuotation";
import SendQuotation from "./Components/Quotation/SendQuotation";
import Guest from "./Components/Guest/Guest";

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { DocumentProvider } from "./Contexts/DocumentContext";

function App() {
  return (
    <DocumentProvider>
      <Router>
        <Switch>
          <Route path="/quotation/new" component={Quotation} />
          <Route path="/quotations" component={QuotationList} />
          <Route path="/guest" component={Guest} />
          <Route path="/quotation/:id" component={ViewQuotation} />
          <Route path="/send" component={SendQuotation} />
          <Route path="/send/:id" component={SendQuotation} />
        </Switch>
      </Router>
    </DocumentProvider>
  );
}

export default App;
