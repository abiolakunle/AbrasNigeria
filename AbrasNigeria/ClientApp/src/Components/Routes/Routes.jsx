import React from "react";
import { Route, Switch } from "react-router-dom";

import Home from "../Guest/Pages/Home";
import Machines from "../Guest/Pages/Machines";
import Machine from "../Guest/Pages/Machine";
import Contact from "../Guest/Pages/Contact";
import Products from "../Guest/Pages/Products";
import Product from "../Guest/Pages/Product";
import Cart from "../Guest/Pages/Cart";
import Checkout from "../Guest/Pages/CheckOut";

import Dashboard from "../Admin/Dashboard/Dashboard";
import DocumentList from "../Admin/Document/DocumentList";
import NewDocument from "../Admin/Document/NewDocument";
import ViewDocument from "../Admin/Document/ViewDocument";
import SendQuotation from "../Admin/Document/SendDocument";
import Login from "../Admin/Auth/Login";
import Register from "../Admin/Auth/Register";
import StockList from "../Admin/Stock/StockList";
import CreateStockProduct from "../Admin/Stock/CreateStockProduct";
import StockProduct from "../Admin/Stock/StockProduct";
import UploadExcel from "../Admin/Upload/UploadExcel";
import NoMatch from "./NoMatch";

import GuestLogin from "../Guest/Pages/GuestLogin";
import GuestRegister from "../Guest/Pages/GuestRegister";

import RouteTitle from "./RouteTitle";
import AdminPrivateRoute from "./AdminPrivateRoute";
import GuestPrivateRoute from "./GuestPrivateRoute";
import userService from "../../Services/userService";
const withTitle = ({ component: Component, title }) => {
  return class Title extends React.Component {
    render() {
      return (
        <React.Fragment>
          <RouteTitle title={title} />
          <Component {...this.props} />
        </React.Fragment>
      );
    }
  };
};

const Routes = () => {
  const { SUPER_ADMIN, ADMIN } = userService.roles;
  return (
    <Switch>
      <Route
        exact
        path="/"
        component={withTitle({ component: Home, title: "Home" })}
      />
      <Route
        exact
        path="/guest/home"
        component={withTitle({ component: Home, title: "Home" })}
      />
      <Route
        exact
        path="/guest/auth/login"
        component={withTitle({ component: GuestLogin, title: "Home" })}
      />
      <Route
        exact
        path="/guest/auth/register"
        component={withTitle({ component: GuestRegister, title: "Home" })}
      />
      <Route
        exact
        path="/guest/machines"
        component={withTitle({ component: Machines, title: "Machines" })}
      />
      <Route
        exact
        path="/guest/machine/:id"
        component={withTitle({ component: Machine, title: "Machine" })}
      />
      <Route
        exact
        path="/guest/contact"
        component={withTitle({ component: Contact, title: "Contact" })}
      />
      <Route
        exact
        path="/guest/products"
        component={withTitle({ component: Products, title: "Products" })}
      />
      <Route
        exact
        path="/guest/product/:id"
        component={withTitle({ component: Product, title: "Product" })}
      />
      <Route
        exact
        path="/guest/cart"
        component={withTitle({ component: Cart, title: "Cart" })}
      />
      <Route
        exact
        path="/guest/checkout"
        component={withTitle({ component: Checkout, title: "Checkout" })}
      />

      <Route
        path="/admin/auth/login"
        component={withTitle({ component: Login, title: "Login" })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN]}
        path="/admin/auth/register"
        component={withTitle({ component: Register, title: "Register" })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/dashboard"
        component={withTitle({ component: Dashboard, title: "Dashboard" })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/document/new"
        component={withTitle({
          component: NewDocument,
          title: "New document"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/document/edit/:id"
        component={withTitle({
          component: NewDocument,
          title: "Edit document"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/document/list"
        component={withTitle({
          component: DocumentList,
          title: "Document list"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/document/:id"
        component={withTitle({
          component: ViewDocument,
          title: "View Document"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/document/send"
        component={withTitle({
          component: SendQuotation,
          title: "Send quotation"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/document/send/:id"
        component={withTitle({
          component: SendQuotation,
          title: "Send quotation"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/store/upload"
        component={withTitle({
          component: UploadExcel,
          title: "Upload excel"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/stock/list"
        component={withTitle({ component: StockList, title: "Stock List" })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/stock/create"
        component={withTitle({
          component: CreateStockProduct,
          title: "Create product"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/stock/:id"
        component={withTitle({
          component: StockProduct,
          title: "Stock product"
        })}
      />
      <AdminPrivateRoute
        roles={[SUPER_ADMIN, ADMIN]}
        path="/admin/upload/excel"
        component={withTitle({
          component: UploadExcel,
          title: "Upload excel"
        })}
      />

      <Route
        component={withTitle({
          component: NoMatch,
          title: "Error page not found"
        })}
      />
    </Switch>
  );
};

export default Routes;
