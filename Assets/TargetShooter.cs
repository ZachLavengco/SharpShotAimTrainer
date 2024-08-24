using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] string mode;

    public Score score;
    public Accuracy accuracy;

    void Update()
    {
        if (mode == "Gridshot" || mode == "Lineshot" || mode == "Flickshot"
                               || mode == "Lineshot_sfMode" || mode == "Flickshot_sfMode")
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out RaycastHit hit))
                {
                    Target target = hit.collider.gameObject.GetComponent<Target>();
                    if (target != null)
                    {
                        //print(hit.point);
                        //print(target.transform.position);

                        float distance = Vector2.Distance(new Vector2(hit.point[0], hit.point[1]), new Vector2(target.transform.position[0], target.transform.position[1]));
                        float pointMultiplier = 0;

                        if (mode == "Gridshot")
                        {
                            if (distance < .14)
                            {
                                pointMultiplier = 3;
                            } else
                            {
                                pointMultiplier = .35f / distance / 2;
                            }
                        } else
                        {
                            if (distance < .11)
                            {
                                pointMultiplier = 3;
                            }
                            else
                            {
                                pointMultiplier = .3f / distance / 2;
                            }
                        }
                        

                        score.increaseScore((int)Mathf.Round(25f * pointMultiplier + 150f));
                        // print((int)Mathf.Round(25f * pointMultiplier + 150f));
                        accuracy.increaseHit(1);

                        target.Hit();

                        if (mode == "Flickshot_sfMode" && StateNameController.roundEnd)
                        {
                            // print(score.GetScore());
                            if (StateNameController.round == 2)
                            {
                                StateNameController.flickshot_sfScore_mid = score.GetScore();
                                StateNameController.midSensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 5)
                            {
                                StateNameController.flickshot_sfScore_high = score.GetScore();
                                StateNameController.highSensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 8)
                            {
                                StateNameController.flickshot_sfScore_low = score.GetScore();
                                StateNameController.lowSensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 11)
                            {
                                StateNameController.flickshot_sfScore_r4 = score.GetScore();
                                StateNameController.round4SensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 14)
                            {
                                StateNameController.flickshot_sfScore_r5 = score.GetScore();
                                StateNameController.round5SensAccuracy += StateNameController.accuracyInt;
                            }
                            StateNameController.roundEnd = false;
                        }
                        else if (mode == "Lineshot_sfMode" && StateNameController.roundEnd)
                        {
                            if (StateNameController.round == 3)
                            {
                                StateNameController.lineshot_sfScore_mid = score.GetScore();
                                StateNameController.midSensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 6)
                            {
                                StateNameController.lineshot_sfScore_high = score.GetScore();
                                StateNameController.highSensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 9)
                            {
                                StateNameController.lineshot_sfScore_low = score.GetScore();
                                StateNameController.lowSensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 12)
                            {
                                StateNameController.lineshot_sfScore_r4 = score.GetScore();
                                StateNameController.round4SensAccuracy += StateNameController.accuracyInt;
                            }
                            else if (StateNameController.round == 15)
                            {
                                StateNameController.lineshot_sfScore_r5 = score.GetScore();
                                StateNameController.round5SensAccuracy += StateNameController.accuracyInt;
                            }
                            StateNameController.roundEnd = false;
                        }
                    }
                } else
                {
                    accuracy.increaseMiss(1);
                }   
            }
        } else if (mode == "Tracking" || mode == "Tracking_sfMode")
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                TargetTracking target = hit.collider.gameObject.GetComponent<TargetTracking>();
                if (target != null)
                {
                    float distance = Vector2.Distance(new Vector2(hit.point[0], hit.point[1]), new Vector2(target.transform.position[0], target.transform.position[1]));
                    int pointMultiplier = 0;
                    if (distance < .8)
                    {
                        pointMultiplier = 3;
                    }
                    else
                    {
                        pointMultiplier = 0;
                    }

                    score.increaseScore(1 * pointMultiplier);
                    accuracy.increaseHit(1);

                    if (mode == "Tracking_sfMode" && StateNameController.roundEnd)
                    {
                        if (StateNameController.round == 1)
                        {
                            StateNameController.tracking_sfScore_mid = score.GetScore();
                            StateNameController.midSensAccuracy += StateNameController.accuracyInt;
                            print(StateNameController.midSensAccuracy);
                        }
                        else if (StateNameController.round == 4)
                        {
                            StateNameController.tracking_sfScore_high = score.GetScore();
                            StateNameController.highSensAccuracy += StateNameController.accuracyInt;
                        }
                        else if (StateNameController.round == 7)
                        {
                            StateNameController.tracking_sfScore_low = score.GetScore();
                            StateNameController.lowSensAccuracy += StateNameController.accuracyInt;
                        }
                        else if (StateNameController.round == 10)
                        {
                            StateNameController.tracking_sfScore_r4 = score.GetScore();
                            StateNameController.round4SensAccuracy += StateNameController.accuracyInt;
                        }
                        else if (StateNameController.round == 13)
                        {
                            StateNameController.tracking_sfScore_r5 = score.GetScore();
                            StateNameController.round5SensAccuracy += StateNameController.accuracyInt;
                        }
                        StateNameController.roundEnd = false;
                    }
                }
            }
            else
            {
                accuracy.increaseMiss(1);
            }
        }
    }
}
