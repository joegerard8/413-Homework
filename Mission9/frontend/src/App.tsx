// importing in the college basketball teams data
import CollegeBasketballData from "./CollegeBasketballTeams.json";
// importing css file
import "./App.css";

// creating an interface for the team object
interface Team {
  tid: number;
  cid: number;
  did: number;
  school: string;
  name: string;
  abbrev: string;
  pop: number;
  city: string;
  state: string;
  latitude: number;
  longitude: number;
}

// extracting the list of team objects from the collegebasketball json file
const { teams } = CollegeBasketballData;

// a simple header component that only returns basic html
function Header() {
  return (
    <>
      <h1>Welcome to the College Basketball Team List</h1>
      <p>Here you can find all of the teams in men's D1 Basketball. Go Zags!</p>
    </>
  );
}

// a component that takes a team object and returns a card with their school, mascot and location. Uses the card css class for styling
function TeamCard({ team }: { team: Team }) {
  return (
    <div className="card">
      <h1>
        The {team.school} {team.name}
      </h1>
      <h3>
        {team.city}, {team.state}
      </h3>
    </div>
  );
}

// tean list component that maps over all the teams and then creates a team card for each team in the list
function TeamList() {
  return (
    <div className="card-grid">
      {teams.map((team: Team) => {
        return <TeamCard key={team.name} team={team} />;
      })}
    </div>
  );
}

// the app function, only renders the header and the team list.
function App() {
  return (
    <>
      <Header />
      <TeamList />
    </>
  );
}

export default App;
