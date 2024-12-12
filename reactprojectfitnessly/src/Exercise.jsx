import { useEffect } from "react";
import { useLocation, useParams } from 'react-router-dom';

const Exercise = () => {
    const { workoutId } = useParams();
    const location = useLocation();
    const { token } = location.state;


    useEffect(() => {
        // Gebruik workoutId en token hier om gegevens op te halen of bewerkingen uit te voeren
        console.log('Workout ID:', workoutId);
        console.log('Token:', token);
    }, [workoutId, token]);

    return (
        <div>
            {/* Jouw code voor de exercise pagina */}
        </div>
    );
};

export default Exercise;
