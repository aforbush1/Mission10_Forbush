import React from "react";

function Header(props: any) {
  return (
    <header className="row align-items-center py-3 bg-dark text-white">
      <div className="col-2 d-flex justify-content-center"></div>
      <div className="col-8">
        <h1 className="display-2">{props.title}</h1>
        <p className="lead">Where champions are made, and fun is guaranteed.</p>
      </div>
    </header>
  );
}

export default Header;
