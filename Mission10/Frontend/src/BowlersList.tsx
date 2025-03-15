{/**This component is pretty slow. It takes like 3-4 seconds for the table to load.
  I could optimize it or add some sort of loading state, but I don't know that that's 
  the point of this assignment. hopefully not an issue.  */}

import { useEffect, useState } from 'react';
import './BowlersList.css'; // Import the custom CSS

// creating an interface for the bowler object to use in the state
interface Bowler {
  bowlerId: number;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerFirstName: string;
  bowlerLastName: string;
  bowlerPhoneNumber: string;
  bowlerMiddleInit: string | null;
  bowlerTeamId: number | null;
  teamName: string | null;
}

// bowlerslist function
const BowlersList = () => {
  // state to hold the bowlers data, uses the above interface
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  //use effect to fetch api data.
  useEffect(() => {
    // backend uses this port for whatever reason, so we have to use it here. 
    fetch('http://localhost:5265/api/bowlers')
      .then((response) => response.json())
      .then((data) => {
        console.log(data.$values); // returns the data in a list format, so we need to access the $values property to get the array of bowlers
        if (Array.isArray(data.$values)) { // checking if its actually a list before setting it, because we will use .map later. 
          setBowlers(data.$values);
        } else {
          console.error('Fetched data is not an array:', data);
        }
      })
      .catch((error) => console.error('Error fetching bowlers:', error));
  }, []);

  return (
    <div>
      {/**Creating a table to store all the bowler data */}
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          
          {bowlers.map((bowler) => (
            // check if bowler team name is either marlins or sharks before rendering the row
            // I suppose I could have handled this on the backend, but this felt easier. definitely more efficient on the backend but i dont really care
            (bowler.teamName === 'Marlins' || bowler.teamName === 'Sharks') && (
              <tr key={bowler.bowlerId}>
                <td>
                  {bowler.bowlerFirstName}{' '}
                  {bowler.bowlerMiddleInit && `${bowler.bowlerMiddleInit} `}{' '}
                  {bowler.bowlerLastName}
                </td>
                <td>{bowler.teamName}</td>
                <td>{bowler.bowlerAddress}</td>
                <td>{bowler.bowlerCity}</td>
                <td>{bowler.bowlerState}</td>
                <td>{bowler.bowlerZip}</td>
                <td>{bowler.bowlerPhoneNumber}</td>
              </tr>
            )
          ))}
        </tbody>
      </table>
    </div>
  );
};
// exporting the function to use in app.tsx
export default BowlersList;
