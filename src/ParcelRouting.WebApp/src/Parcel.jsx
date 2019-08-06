import React from 'react';
import ItemTypes from './ItemTypes';
import { useDrag } from 'react-dnd';

const style = {
  border: '1px dashed gray',
  backgroundColor: 'white',
  padding: '0.5rem 1rem',
  marginRight: '1.5rem',
  marginBottom: '1.5rem',
  float: 'left',
};

const Parcel = ({ id, text, weight, declaredValue, moveTo, signOff, isSignedOff, currentDepartment }) => {
  const item = { id, weight, declaredValue, isSignedOff, type: ItemTypes.PARCEL };

  const [{ opacity }, drag] = useDrag({
    item,
    end(item, monitor) {
      const department = monitor.getDropResult()
      if (item && department) {
        let alertMessage = ''
        const accepted = department.acceptsDeclaredValue(item.declaredValue, item.isSignedOff) && department.acceptsWeight(item.weight)
          ? 'accepted'
          : 'rejected';

        alertMessage = `${department.name} ${accepted} the parcel`;
        
        if (accepted === 'accepted') {
          department.process(signOff);
          moveTo(department.name);
        } else {
          alert(alertMessage);
        }
      }
    },
    collect: monitor => ({
      opacity: monitor.isDragging() ? 0.4 : 1,
    }),
  });

  return (
    <div ref={drag} style={{ ...style, opacity }} className="parcel">
      {text}
      {weight > 0 && <div className="parcel-weight">{weight}</div>}
      {declaredValue > 0 && <div className="parcel-declaredValue">{declaredValue} {isSignedOff ? '(signed)' : ''}</div>}
      {`current department ${currentDepartment}`}
    </div>)
}

export default Parcel
