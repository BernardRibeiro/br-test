import React from "react";
import { Route, Switch } from "react-router-dom";

import Layout from "./../layout/Layout";
import Home from "./../home/Home";
import Calculation from "./../calculation/Calculation";

function Routes() {
  return (
    <Layout>
      <Switch>
        <Route path="/" exact={true} component={Home} />
        <Route path="/calculation" exact={true} component={Calculation} />
      </Switch>
    </Layout>
  );
}

export default Routes;
