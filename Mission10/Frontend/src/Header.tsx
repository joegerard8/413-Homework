import React from "react";
// header component. super simple. is a react functional component object.
const Header: React.FC = () => {
  return (
    <header className="bg-blue-600 text-white py-4 px-6 shadow-md">
      <h1 className="text-2xl font-bold">Bowler Directory</h1>
      <p className="text-lg mt-1">
        Browse the list of bowlers along with their teams and contact details.
      </p>
    </header>
  );
};

export default Header;
