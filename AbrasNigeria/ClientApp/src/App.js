import React from "react";

import Dashboard from "./Components/Admin/Dashboard/Dasboard";
import DocumentList from "./Components/Admin/Document/DocumentList";
import NewDocument from "./Components/Admin/Document/NewDocument";
import ViewDocument from "./Components/Admin/Document/ViewDocument";
import SendQuotation from "./Components/Admin/Document/SendDocument";
import Guest from "./Components/Guest/Guest";
import UploadExcel from "./Components/Admin/Stock/UploadExcel";
import Login from "./Components/Admin/Auth/Login";
import Register from "./Components/Admin/Auth/Register";
import List from "./Components/Admin/Stock/List";
import CreateProduct from "./Components/Admin/Stock/CreateProduct";
import Product from "./Components/Admin/Stock/Product";

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
          <PrivateRoute path="/admin/dashboard" component={Dashboard} />
          <PrivateRoute path="/admin/document/new" component={NewDocument} />
          <PrivateRoute path="/admin/document/list" component={DocumentList} />
          <PrivateRoute path="/admin/document/:id" component={ViewDocument} />
          <PrivateRoute path="/admin/document/send" component={SendQuotation} />
          <PrivateRoute
            path="admin/document/send/:id"
            component={SendQuotation}
          />
          <PrivateRoute path="/admin/store/upload" component={UploadExcel} />
          <PrivateRoute path="/admin/stock/list" component={List} />
          <PrivateRoute path="/admin/stock/create" component={CreateProduct} />
          <PrivateRoute path="/admin/stock/:id" component={Product} />
        </Switch>
      </Router>
    </DocumentProvider>
  );
};

export default App;
