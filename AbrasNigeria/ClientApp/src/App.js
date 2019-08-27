import React from "react";

import DocumentList from "./Components/Admin/Dashboard/DocumentList";
import NewDocument from "./Components/Admin/Dashboard/NewDocument";
import ViewDocument from "./Components/Admin/Dashboard/ViewDocument";
import SendQuotation from "./Components/Admin/Dashboard/SendQuotation";
import Guest from "./Components/Guest/Guest";
import UploadExcel from "./Components/Admin/Dashboard/UploadExcel";
import Login from "./Components/Admin/Auth/Login";

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { DocumentProvider } from "./Contexts/DocumentContext";

const App = () => {
  return (
    <DocumentProvider>
      <Router>
        <Switch>
          <Route exact path="/" component={Guest} />
          <Route path="/guest" component={Guest} />
          <Route path="/auth/login" component={Login} />
          <Route path="/admin/document/new" component={NewDocument} />
          <Route path="/admin/document/list" component={DocumentList} />
          <Route path="/admin/document/:id" component={ViewDocument} />
          <Route path="/send" component={SendQuotation} />
          <Route path="/send/:id" component={SendQuotation} />
          <Route path="/upload" component={UploadExcel} />
        </Switch>
      </Router>
    </DocumentProvider>
  );
};

export default App;
