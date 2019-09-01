import React from "react";

import DocumentList from "./Components/Admin/Document/DocumentList";
import NewDocument from "./Components/Admin/Document/NewDocument";
import ViewDocument from "./Components/Admin/Document/ViewDocument";
import SendQuotation from "./Components/Admin/Document/SendDocument";
import Guest from "./Components/Guest/Guest";
import UploadExcel from "./Components/Admin/Store/UploadExcel";
import Login from "./Components/Admin/Auth/Login";
import Register from "./Components/Admin/Auth/Register";

import PrivateRoute from "./Components/Routes/PrivateRoute";

import { history } from "./Helpers/history";

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { DocumentProvider } from "./Contexts/DocumentContext";

const App = () => {
  return (
    <DocumentProvider>
      <Router history={history} forceRefresh={true}>
        <Switch>
          <Route exact path="/" component={Guest} />
          <Route path="/guest" component={Guest} />
          <Route path="/admin/auth/login" component={Login} />
          <Route path="/admin/auth/register" component={Register} />
          <PrivateRoute path="/admin/document/new" component={NewDocument} />
          <PrivateRoute path="/admin/document/list" component={DocumentList} />
          <PrivateRoute path="/admin/document/:id" component={ViewDocument} />
          <PrivateRoute path="/admin/document/send" component={SendQuotation} />
          <PrivateRoute
            path="admin/document/send/:id"
            component={SendQuotation}
          />
          <PrivateRoute path="/admin/store/upload" component={UploadExcel} />
        </Switch>
      </Router>
    </DocumentProvider>
  );
};

export default App;
