import React, { useState, createContext } from "react";

import api from "./../common/api";

const Context = createContext();

function CalculationContext({ children }) {
  const [result, setResult] = useState(0);

  const executeCalculation = (initialValue, months) => {
    const preparedUrl = `/CalculaJuros?valorInicial=${initialValue}&meses=${months}`;

    api.get(preparedUrl).then((resp) => {
      setResult(resp.data);
    });
  };

  return (
    <Context.Provider
      value={{
        executeCalculation,
        result,
      }}
    >
      {children}
    </Context.Provider>
  );
}

export { CalculationContext, Context };
