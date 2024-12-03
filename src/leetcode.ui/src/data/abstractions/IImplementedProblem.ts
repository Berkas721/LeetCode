export interface IImplementedProblem {
  id: string;
  problemId: number;
  languageId: number;
  problemCode: string;
  defaultSolutionCode: string;
  workingSolutionCode: string;
  createInfo: {
    date: string;
    agentId: string;
  };
}

export interface IImplementedProblemBaseFields {
  id: string;
  problemId: number;
  languageId: number;
}