import { useEffect, useState } from "react";
import { Bowler } from "../types/Bowler";

// BowlerList is a function component
function BowlerList() {
  // These hooks are managing side effects and state in a function component
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);

  // This hook is used to perform side effects in the component. In this case it is used to fetch data from the server.
  useEffect(() => {
    // the aynchronous function 'fetchBowlerData' is defined and immediatly invoked.
    const fetchBowlerData = async () => {
      const rsp = await fetch("http://localhost:5298/Bowling");
      // This function uses the 'fetch' API to make a GET request. It converts the response to JSON using  '.json()'
      const b = await rsp.json();
      // The data is stored in the 'bowlerData' state calling 'setBowlerData'
      setBowlerData(b);
    };
    fetchBowlerData();
  }, []);

  return (
    <>
      <table className="table table-bordered">
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
          {bowlerData.map(
            (f) =>
              (f.teamName === "Marlins" || f.teamName === "Sharks") && (
                <tr key={f.bowlerId}>
                  <td>
                    {f.bowlerFirstName}{" "}
                    {f.bowlerMiddleInit && ` ${f.bowlerMiddleInit}`}{" "}
                    {/*Checks if the middle initial is blank*/}
                    {f.bowlerLastName}
                  </td>
                  <td>{f.teamName}</td>
                  <td>{f.bowlerAddress}</td>
                  <td>{f.bowlerCity}</td>
                  <td>{f.bowlerState}</td>
                  <td>{f.bowlerZip}</td>
                  <td>{f.bowlerPhoneNumber}</td>
                </tr>
              ),
          )}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;
