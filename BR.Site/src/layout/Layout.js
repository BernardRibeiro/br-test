import React from "react";
import Menu from "./../menu/Menu";

function Layout({ children }) {
  return (
    <>
      <Menu />
      <div className="container">{children}</div>
    </>
  );
}

export default Layout;
