/// \defgroup abstractgui Abstract GUI
/// \ingroup engines
/// All this classes, structs and enumerations are elements for the abstract gui API.
/// The abstract gui API contains all logic for default gui handling. All known
/// gui components are implemented as abstract classes. To create your own gui,
/// extend from the abstract basic class and implement the Draw()-Method for drawing
/// the given component. All other features for this component are implemented by
/// this API.